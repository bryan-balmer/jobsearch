using JobsNet.JobSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.JobSearch.Sites
{
    public interface ISite
    {
        string GetSearchUrl(SearchArguments arguments);
        string[] GetParentNodes();
        ResultNames GetResultNames();
        void SetKey(string key);
    }
}
