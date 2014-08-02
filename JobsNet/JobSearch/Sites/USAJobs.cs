using JobsNet.JobSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JobsNet.JobSearch.Sites
{
    public class USAJobs : ISite
    {
        private string _baseUrl = "https://data.usajobs.gov/api/jobs?";
        private string _keyword = "Keyword=";
        private string _locationName = "LocationName=";

        public string GetSearchUrl(SearchArguments arguments)
        {
            string keywords = HttpUtility.UrlEncode(arguments.Keywords);
            string location = HttpUtility.UrlEncode(arguments.Location);

            StringBuilder sb = new StringBuilder();
            sb.Append(_baseUrl)
                .Append(_keyword).Append(keywords)
                .Append("&").Append(_locationName).Append(location);

            return sb.ToString();
        }

        public string[] GetParentNodes()
        {
            return new string[] { "JobData" };
        }

        public ResultNames GetResultNames()
        {
            ResultNames resultNames = new ResultNames
            {
                ResultTitle = "JobTitle",
                ResultCompany = "OrganizationName",
                ResultLocation = "Locations",
                ResultDescription = "JobSummary",
                ResultUrl = "ApplyOnlineURL"
            };

            return resultNames;
        }

        public void SetKey(string key) { }
    }
}
