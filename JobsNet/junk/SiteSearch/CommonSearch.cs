using JobsNet.Core.Search;
using JobsNet.SiteSearch.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.SiteSearch
{
    public class JobSites
    {
        public static List<string> Names = new List<string>();

        public static JobSites AngelList = new JobSites(new AngelListSearch());
        public static JobSites GitHub = new JobSites(new GitHubSearch());
        public static JobSites Indeed = new JobSites(new IndeedSearch());
        public static JobSites USAJobs = new JobSites(new USAJobsSearch());

        private ISite _site;

        private JobSites(ISite site) 
        {
            _site = site;
            Names.Add(this.ToString());
        }

        public async Task Search()
        {
            await _site.Search();
        }

        public static void SetArguments<T>(T arguments)
        {
            if (typeof(T) == typeof(IndeedArguments))
            {
                
            }
        }
    }

    public class CommonSearch
    {
        private CommonSearchArgs _arguments = new CommonSearchArgs();
        
        private AngelListSearch _angelList = new AngelListSearch();
        private GitHubSearch _gitHub = new GitHubSearch();
        private IndeedSearch _indeed = new IndeedSearch();
        private USAJobsSearch _usaJobs = new USAJobsSearch();

        public CommonSearch(CommonSearchArgs arguments)
        {
            _arguments = arguments;
            SetUpSiteArgs();
        }

        private void SetUpSiteArgs()
        {
            
        }

        public void SetArgValues(CommonSearchArgs arguments)
        {
            _arguments = arguments;
        }

        public async Task Search<S>()
            where S : ISite
        {

        }
    }
}
