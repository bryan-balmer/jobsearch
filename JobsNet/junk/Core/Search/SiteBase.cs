using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.Core.Search
{
    public interface ISite
    {
        Task Search();
        Enum ArgumentEnum();
        Enum ResultEnum();
    }

    public abstract class SiteBase<A, R> : ISite
        where A: struct
        where R: struct
    {
        public override abstract Enum ArgumentEnum();
        public override abstract Enum ResultEnum();

        protected ISearcher<R> searcher;
        protected SearchArguments<A> searchArguments;
        protected List<SearchResult<R>> searchResults = new List<SearchResult<R>>();
        public List<SearchResult<R>> SearchResults
        {
            get { return searchResults; }
        }
        
        protected string baseUrl = string.Empty;

        public SiteBase(SearcherType st)
        {
            searcher = new Searcher<R>(st);
            SetUpArguments();
        }

        protected virtual void SetUpArguments()
        {
            var argNames = new A[]{};
            argNames = (A[])Enum.GetValues(typeof(A));
            searchArguments = new SearchArguments<A>(argNames);
        }

        public void SetArgValue(A args, string value)
        {
            searchArguments.SetValue(args, value);
        }

        public void SetArgValues(IDictionary<A, string> arguments)
        {
            foreach(A key in arguments.Keys)
            {
                searchArguments.SetValue(key, arguments[key]);
            }
        }

        public override async Task Search()
        {
            searcher.SetSearchUrl(searchArguments.SearchUrl(baseUrl));
            var resultNames = Enum.GetNames(typeof(R));
            searchResults = await searcher.Search();
        }
    }
}
