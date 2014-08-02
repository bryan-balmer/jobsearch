using JobsNet.Core.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.SiteSearch
{
    public enum GitHubSearchArgs
    {
        description, location, lat, full_time
    }

    public enum GitHubResults
    {
        id, created_at, title, location, type,
        description, how_to_apply, company,
        company_url, company_logo, url
    }

    public class GitHubSearch : SiteBase<GitHubSearchArgs, GitHubResults>
    {
        public GitHubSearch()
            : base(SearcherType.JSON)
        {
            baseUrl = "http://jobs.github.com/positions.json?";
        }

    }
}
