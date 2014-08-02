using JobsNet.Core.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.SiteSearch
{
    public enum IndeedSearchArgs
    {
        publisher, v, format, callback, q, l, sort, radius,
        st, jt, start, limit, fromage, highlight, filter,
        latlong, co, chnl, userip, useragent
    }

    public enum IndeedResults
    {
        jobtitle, company, city, state, country,
        formattedLocation, source, date, snippet,
        url, latitude, longitude, jobkey, sponsered,
        expired, indeedApply, formattedLocationFull, 
        formattedRelativeTime
    }

    public class IndeedSearch : SiteBase<IndeedSearchArgs, IndeedResults>
    {

        public IndeedSearch()
            :base(SearcherType.XML)
        {
            baseUrl = "http://api.indeed.com/ads/apisearch?";
            searcher.SetChildNodes(new string[] { "response", "results" });
        }

        protected override void SetUpArguments()
        {
            base.SetUpArguments();
            
            SetArgValue(IndeedSearchArgs.publisher, "7262713229917866");
            SetArgValue(IndeedSearchArgs.v, "2");
        }
    }
}
