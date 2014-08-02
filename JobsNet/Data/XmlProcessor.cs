using JobsNet.JobSearch.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.XPath;

namespace JobsNet.Data
{
    public class XmlProcessor : DataProcessor
    {
        private XmlNode _nodes;

        public XmlProcessor(string xmlString)
        {
            GetNodes(xmlString);
        }

        private void GetNodes(string xmlString)
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                doc.LoadXml(xmlString);
                _nodes = doc;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine("Error with {0} loading the Xml Document: {1}", ex.Source, ex.Message);
            }
            catch (XPathException ex)
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

        public override void FindRelevantNodes(string[] parentNodes, ResultNames resultNames)
        {
            foreach (string s in parentNodes)
                _nodes = _nodes.SelectSingleNode(s);

            foreach (XmlNode node in _nodes)
            {
                JobNodeItem jobItem = new JobNodeItem(node, resultNames);
                _jobItems.Add(jobItem);
            }
        }
    }
}
