using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.Search
{
    public enum SearchType
    {
        XML, JSON
    }

    public class SearchTypeFactory
    {
        public static ISearcherStrategy GetSearch(SearchType st, IEnumerable<string> parentNodes, TargetNode targetNode)
        {
            if (st == SearchType.XML)
                return new XMLSearch(parentNodes, targetNode);
            else
                return new JSONSearch(parentNodes, targetNode);
        }
    }

    public interface ISearcherStrategy
    {
        Task<IEnumerable<JobResult>> Search(string searchUrl);
    }
}
