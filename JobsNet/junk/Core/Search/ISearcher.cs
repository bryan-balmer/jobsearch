using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.Core.Search
{
    public interface ISearcher<R> 
        where R : struct
    {
        void SetSearchUrl(string searchUrl);
        Task<List<SearchResult<R>>> Search();
        void SetChildNodes(IEnumerable<string> childNodes);
    }
}
