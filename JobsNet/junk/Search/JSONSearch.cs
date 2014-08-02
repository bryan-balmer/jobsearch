using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.Search
{
    public class JSONSearch : SearchBase
    {
        public JSONSearch(IEnumerable<string> parentNodes, TargetNode targetNode)
            : base(parentNodes, targetNode) { }

        protected override void GetResultsFromDownloadedString(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                //JTokenReader reader = new JTokenReader(JToken.Parse(e.Result));
                JToken token = JToken.Parse(e.Result);

                foreach (string s in _parentNodes)
                    token = token.SelectToken(s);

                foreach (JToken t in token)
                {
                    AddJobToList(t);
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

        private void AddJobToList(JToken token)
        {
            _jobResults.Add(new JobResult
            {
                Title = token.SelectToken(_targetNode.TitleNode).ToString(),
                Company = token.SelectToken(_targetNode.CompanyNode).ToString(),
                Description = token.SelectToken(_targetNode.DescriptionNode).ToString(),
                Location = token.SelectToken(_targetNode.LocationNode).ToString()
            });
        }
    }
}
