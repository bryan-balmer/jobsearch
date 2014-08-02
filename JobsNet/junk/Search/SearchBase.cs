using JobsNet.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.Search
{
    public class TargetNode
    {
        public IEnumerable<string> TargetNames { get; set; }
        public string TitleNode { get; set; }
        public string CompanyNode { get; set; }
        public string LocationNode { get; set; }
        public string DescriptionNode { get; set; }
    }

    public abstract class SearcherBase
    {
        protected IDataRequest _dataRequest;

        public SearcherBase(IDataRequest dataRequest)
        {
            _dataRequest = dataRequest;
        }
    }

    public abstract class SearchBase : ISearcherStrategy 
    {
        protected IEnumerable<string> _parentNodes;
        protected TargetNode _targetNode;
        protected List<JobResult> _jobResults = new List<JobResult>();

        public SearchBase(IEnumerable<string> parentNodes, TargetNode targetNodes)
        {
            _parentNodes = parentNodes;
            _targetNode = targetNodes;
        }

        protected abstract void GetResultsFromDownloadedString(object sender, DownloadStringCompletedEventArgs e);

        public async Task<IEnumerable<JobResult>> Search(string searchUrl)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadStringCompleted += GetResultsFromDownloadedString;

                try
                {
                    _jobResults.Clear();
                    await client.DownloadStringTaskAsync(searchUrl);
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
                    Debug.WriteLine("Network error with {0} downloading string: {1}", ex.Source, ex.Message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Unspecified error: {0}", ex.ToString());
                }
            }

            return _jobResults;
        }
    }
}
