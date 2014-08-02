using JobsNet.Data;
using JobsNet.JobSearch.Models;
using JobsNet.JobSearch.Sites;
using JobsNet.Web;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.JobSearch
{
    public enum JobSites
    {
        Indeed, GitHub, USAJobs
    }

    public class Search
    {
        private ISite _site;
        private IDataRequest _dataRequest;

        public JobSites[] JobSiteNames
        {
            get
            {
                return (JobSites[])Enum.GetValues(typeof(JobSites));
            }
        }

        public Search(JobSites jobSite) 
        {
            _site = SearchSite.Instance.GetSite(jobSite);
            _dataRequest = JobNetBindings.Instance.Get<IDataRequest>();
        }

        public void SetJobSite(JobSites jobSite)
        {
            _site = SearchSite.Instance.GetSite(jobSite);
        }

        public async Task<IEnumerable<JobPosting>> SearchJobs(SearchArguments arguments)
        {
            IEnumerable<JobPosting> jobPostings = new List<JobPosting>();
            try
            {
                string data = await _dataRequest.GetData(_site.GetSearchUrl(arguments));
                DataHandler dataHandler = new DataHandler(data);
                jobPostings = dataHandler.GetJobPostings(data, _site.GetParentNodes(), _site.GetResultNames());
                return jobPostings;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while searching: {0}", e.ToString());
            }
            return jobPostings;
        }

        public void SetKey(string key)
        {
            _site.SetKey(key);
        }
    }
}
