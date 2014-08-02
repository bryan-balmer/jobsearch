using JobsNet.Core.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.SiteSearch
{
    public enum AngelListSearchArgs
    {

    }

    public enum AngelListResults
    {
        angellist_url, created_at, currency_code, description,
        equity_cliff, equity_max, equity_min, equity_vest,
        id, job_type, salary_max, salary_min, title
    }

    public class AngelListSearch : SiteBase<AngelListSearchArgs, AngelListResults>
    {
        public AngelListSearch()
            :base(SearcherType.JSON) 
        {
            baseUrl = "https://api.angel.co/1/jobs";
            searcher.SetChildNodes(new string[] { "jobs" });
        }

        public override Enum ArgumentEnum()
        {
            var argsEnum = Enum.GetValues(typeof(AngelListSearchArgs));
            
        }
    }
}
