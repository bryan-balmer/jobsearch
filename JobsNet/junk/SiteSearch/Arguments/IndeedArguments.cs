using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.SiteSearch.Arguments
{
    public enum IndeedFormat { xml, json }
    public enum IndeedSort { relevance, date }
    public enum IndeedSiteType { jobsite, employer }
    public enum IndeedJobType { fulltime, parttime, contract, internship, temporary }

    public class IndeedArguments
    {
        public Argument<string> PublisherID = new Argument<string>("publisher", string.Empty);
        public Argument<string> Version = new Argument<string>("v", "2");
        public Argument<IndeedFormat> Format = new Argument<IndeedFormat>("format", IndeedFormat.xml);
        public Argument<string> Query = new Argument<string>("q", string.Empty);
        public Argument<string> Location = new Argument<string>("l", string.Empty);
        public Argument<IndeedSort> Sort = new Argument<IndeedSort>("sort", IndeedSort.relevance);
        public Argument<int> Radius = new Argument<int>("radius", 25);
        public Argument<IndeedSiteType> SiteType = new Argument<IndeedSiteType>("st", IndeedSiteType.jobsite);
        public Argument<IndeedJobType> JobType = new Argument<IndeedJobType>("jt", IndeedJobType.fulltime);
        public Argument<int> Start = new Argument<int>("start", 0);
        public Argument<int> Limit = new Argument<int>("limit", 10);
        public Argument<int> FromAge = new Argument<int>("fromage", 30);
        public Argument<string> Country = new Argument<string>("co", "us");
        public Argument<string> IPAddress = new Argument<string>("userip", string.Empty);
        public Argument<string> UserAgent = new Argument<string>("useragent", string.Empty);
    }
}
