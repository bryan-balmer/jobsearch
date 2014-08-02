using JobsNet.JobSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JobsNet.JobSearch.Sites
{
    public class GitHub : ISite
    {
        private string _baseUrl = "http://jobs.github.com/positions.json?";
        private string _description = "description=";
        private string _location = "location=";

        public string GetSearchUrl(SearchArguments arguments)
        {
            string keywords = HttpUtility.UrlEncode(arguments.Keywords);
            string location = HttpUtility.UrlEncode(arguments.Location);

            StringBuilder sb = new StringBuilder();
            sb.Append(_baseUrl)
                .Append(_description).Append(keywords)
                .Append("&").Append(_location).Append(location);

            return sb.ToString();
        }

        public string[] GetParentNodes()
        {
            return new string[] { };
        }

        public ResultNames GetResultNames()
        {
            ResultNames resultNames = new ResultNames
            {
                ResultTitle = "title",
                ResultCompany = "company",
                ResultLocation = "location",
                ResultDescription = "description",
                ResultUrl = "company_url"
            };

            return resultNames;
        }

        public void SetKey(string key) { }
    }
}
