using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JobsNet.Core.Search
{
    public enum SearcherType
    {
        XML, JSON
    }

    internal class Searcher<R> : ISearcher<R>
        where R : struct
    {
        private string _searchUrl = string.Empty;
        private IEnumerable<string> _childNodes;
        private List<SearchResult<R>> _searchResults = new List<SearchResult<R>>();
        private R[] _resultNames = (R[])Enum.GetValues(typeof(R));
        
        private SearcherType _searchType;
        public SearcherType SearchType
        {
            get { return _searchType; }
            set { _searchType = value; }
        }

        public Searcher(SearcherType t)
        {
            _searchType = t;
        }

        public void SetSearchUrl(string searchUrl)
        {
            _searchUrl = searchUrl;
        }

        public async Task<List<SearchResult<R>>> Search()
        {
            _searchResults.Clear();

            using (var client = new WebClient())
            {
                if (_searchType == SearcherType.XML)
                    client.DownloadStringCompleted += XMLDownloadComplete;
                else if (_searchType == SearcherType.JSON)
                    client.DownloadStringCompleted += JSONDownloadComplete;

                try
                {
                    await client.DownloadStringTaskAsync(_searchUrl);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Debug.WriteLine("Error building search address: {0}", ex.Message);
                }
                catch (ArgumentNullException ex)
                {
                    Debug.WriteLine("Argument null error with {0}: {1}", ex.Source, ex.Message);
                }
                catch (WebException ex)
                {
                    Debug.WriteLine("Network error with {0} downloading Json: {1}", ex.Source, ex.Message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Unspecified error: {0}", ex.ToString());
                }

                return _searchResults;
            }
        }

        private void JSONDownloadComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                var tokenReader = new JTokenReader(JToken.Parse(e.Result));
                var tokens = JToken.Parse(e.Result);

                if (_childNodes.Count() > 0)
                {
                    tokens = tokens.SelectToken(_childNodes.ElementAt(0));
                    
                    for (int i = 1; i < _childNodes.Count(); i++)
                    {
                        tokens = tokens.SelectToken(_childNodes.ElementAt(i));
                    }
                }

                foreach (JToken token in tokens)
                {
                    var result = new SearchResult<R>(_resultNames);

                    foreach (R t in _resultNames)
                    {
                        var resultValue = token.SelectToken(t.ToString());

                        if (resultValue != null)
                            result.SetValue(t, (string)resultValue);
                    }

                    _searchResults.Add(result);
                }
            }
            catch (JsonReaderException ex)
            {
                Debug.WriteLine("Error in {0} reading JSON: {1}", ex.Source, ex.Message);
            }
            catch (JsonSerializationException ex)
            {
                Debug.WriteLine("Serialization Error in {0}: {1}", ex.Source, ex.Message);
            }
            catch (JsonException ex)
            {
                Debug.WriteLine("Error in {0} with JSON: {1}", ex.Source, ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unspecified error: {0}", ex.Message);
            }
        }

        private void XMLDownloadComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            var document = new XmlDocument();

            try
            {
                document.LoadXml(e.Result);
                XmlNode children = document;

                if (_childNodes.Count() > 0)
                {
                    children = document.SelectSingleNode(_childNodes.ElementAt(0));

                    for (int i = 1; i < _childNodes.Count(); i++)
                    {
                        children = children.SelectSingleNode(_childNodes.ElementAt(i));
                    }
                }

                foreach (XmlNode n in children)
                {
                    var result = new SearchResult<R>(_resultNames);

                    foreach (R r in _resultNames)
                    {
                        var resultValue = n.SelectSingleNode(r.ToString());

                        if (resultValue != null)
                            result.SetValue(r, resultValue.InnerText);
                    }

                    _searchResults.Add(result);
                }
            }
            catch (XmlException ex)
            {
                Debug.WriteLine("Error with {0} loading the Xml Document: {1}", ex.Source, ex.Message);
                return;
            }
            catch (System.Xml.XPath.XPathException ex)
            {
                Debug.WriteLine("Error in {0} finding XPath expression: {1}", ex.Source, ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Null reference in {0} parsing XML: {1}", ex.TargetSite.Name, ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unspecified error: {0}", ex.Message);
            }
        }

        public void SetChildNodes(IEnumerable<string> childNodes)
        {
            _childNodes = childNodes;
        }
    }
}
