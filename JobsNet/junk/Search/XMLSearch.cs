using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JobsNet.Search
{
    public class XMLSearch : SearchBase
    {
        public XMLSearch(IEnumerable<string> parentNodes, TargetNode targetNode)
            : base(parentNodes, targetNode) { }

        protected override void GetResultsFromDownloadedString(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(e.Result);

                XmlNode nodes = document;
                foreach (string s in _parentNodes)
                    nodes = nodes.SelectSingleNode(s);

                foreach (XmlNode n in nodes)
                {
                    AddJobToList(n);
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

        private void AddJobToList(XmlNode n)
        {
            _jobResults.Add(new JobResult
            {
                Title = n.SelectSingleNode(_targetNode.TitleNode).InnerText,
                Company = n.SelectSingleNode(_targetNode.CompanyNode).InnerText,
                Description = n.SelectSingleNode(_targetNode.DescriptionNode).InnerText,
                Location = n.SelectSingleNode(_targetNode.LocationNode).InnerText
            });
        }
    }
}
