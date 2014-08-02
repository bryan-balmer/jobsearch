using JobsNet.JobSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JobsNet.JobSearch.Sites
{
    public class Indeed : ISite
    {
        private string _baseUrl = "http://api.indeed.com/ads/apisearch?";
        private string _publisherID;
        private string _version = "v=2";
        private string _query = "q=";
        private string _location = "l=";

        public string GetSearchUrl(SearchArguments arguments)
        {
            string keywords = HttpUtility.UrlEncode(arguments.Keywords);
            string location = HttpUtility.UrlEncode(arguments.Location);

            StringBuilder sb = new StringBuilder();
            sb.Append(_baseUrl).Append(_publisherID)
                .Append("&").Append(_version)
                .Append("&").Append(_query).Append(keywords)
                .Append("&").Append(_location).Append(location);

            return sb.ToString();
        }

        public string[] GetParentNodes()
        {
            return new string[] { "response", "results" };
        }

        public ResultNames GetResultNames()
        {
            ResultNames resultNames = new ResultNames
            {
                ResultTitle = "jobtitle",
                ResultCompany = "company",
                ResultLocation = "formattedLocationFull",
                ResultDescription = "snippet",
                ResultUrl = "url"
            };

            return resultNames;
        }

        public void SetKey(string publisherID)
        {
            _publisherID = "publisher=" + publisherID;
        }
    }
}
