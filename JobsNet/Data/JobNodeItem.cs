using JobsNet.JobSearch.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JobsNet.Data
{
    public class JobNodeItem : JobPosting
    {
        public JobNodeItem(JToken token, ResultNames resultNames)
        {
            Title = token.SelectToken(resultNames.ResultTitle).ToString();
            Company = token.SelectToken(resultNames.ResultCompany).ToString();
            Location = token.SelectToken(resultNames.ResultLocation).ToString();
            Description = token.SelectToken(resultNames.ResultDescription).ToString();
            Url = token.SelectToken(resultNames.ResultDescription).ToString();
        }

        public JobNodeItem(XmlNode node, ResultNames resultNames)
        {
            Title = node.SelectSingleNode(resultNames.ResultTitle).InnerText;
            Company = node.SelectSingleNode(resultNames.ResultCompany).InnerText;
            Location = node.SelectSingleNode(resultNames.ResultLocation).InnerText;
            Description = node.SelectSingleNode(resultNames.ResultDescription).InnerText;
        }
    }
}
