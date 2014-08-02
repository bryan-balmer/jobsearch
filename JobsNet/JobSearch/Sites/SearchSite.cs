using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.JobSearch.Sites
{
    //public enum SiteList
    //{
    //    GitHub, 
    //    Indeed, 
    //    USAJobs
    //}

    public class SearchSite
    {
        private static SearchSite _instance = new SearchSite();
        public static SearchSite Instance { get { return _instance; } }

        private ISite _indeed;
        private ISite _gitHub;
        private ISite _usaJobs;

        private SearchSite()
        {
            _indeed = new Indeed();
            _gitHub = new GitHub();
            _usaJobs = new USAJobs();
        }

        public ISite GetSite(JobSites jobSites)
        {
            if (jobSites == JobSites.Indeed)
                return _indeed;
            if (jobSites == JobSites.GitHub)
                return _gitHub;
            else
                return _usaJobs;
        }

        //private static Dictionary<SiteList, ISite> _sites = new Dictionary<SiteList, ISite>();
        //private static List<string> _siteNames = new List<string>();
        //private static Dictionary<SiteList, SearchSite> _searchSites = new Dictionary<SiteList, SearchSite>();

        //public static List<string> SiteNames
        //{
        //    get
        //    {
        //        return _siteNames;
        //    }
        //}

        //private static SearchSite GitHub = new SearchSite(SiteList.GitHub, new GitHub(), false);
        //private static SearchSite Indeed = new SearchSite(SiteList.Indeed, new Indeed(), true);
        //private static SearchSite USAJobs = new SearchSite(SiteList.USAJobs, new USAJobs(), false);

        //private ISite _site;
        //public bool RequiresKey;
        //public ISite Instance
        //{
        //    get { return _site; }
        //}

        //private SearchSite(SiteList name, ISite site, bool requiresKey)
        //{
        //    _site = site;
        //    _siteNames.Add(name.ToString());
        //    _sites.Add(name, site);
        //    RequiresKey = requiresKey;
        //    _searchSites.Add(name, this);
        //}

        //public static ISite GetSite(SiteList site) 
        //{
        //    return _sites[site];
        //}

        //public static void SetKey(SiteList site, string key)
        //{
        //    if (_searchSites[site].RequiresKey)
        //    {
        //        IKeyRequiredSite keySite = (IKeyRequiredSite)GetSite(site);
        //        keySite.SetKey(key);
        //    }
        //}
    }
}
