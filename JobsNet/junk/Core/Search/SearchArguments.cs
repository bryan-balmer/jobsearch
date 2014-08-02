using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JobsNet.Core.Search
{
    public class SearchArguments<A>
    {
        private Dictionary<A, string> _searchArguments = new Dictionary<A, string>();

        public SearchArguments(IEnumerable<A> arguments)
        {
            foreach (A key in arguments)
            {
                _searchArguments.Add(key, string.Empty);
            }
        }

        public SearchArguments(Dictionary<A, string> argumentsAndValues)
        {
            _searchArguments = argumentsAndValues;
        }

        public void SetValue(A argument, string value)
        {
            if (_searchArguments.Keys.Contains(argument))
                _searchArguments[argument] = value;
        }

        public string SearchUrl(string baseUrl)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(baseUrl);

            bool firstElementAdded = false;
            string firstElementValue = string.Empty;

            if(_searchArguments.Count > 0)
                firstElementValue = _searchArguments.ElementAt(0).Value;

            if (firstElementValue != string.Empty)
            {
                sb.Append(_searchArguments.ElementAt(0).Key.ToString())
                    .Append("=").Append(firstElementValue);
                firstElementAdded = true;
            }

            for (int i = 1; i < _searchArguments.Count; i++)
            {
                var element = _searchArguments.ElementAt(i);
                if (element.Value != string.Empty)
                {
                    var arg = HttpUtility.UrlEncode(element.Key.ToString());
                    var value = HttpUtility.UrlEncode(element.Value);

                    if (firstElementAdded) sb.Append("&");

                    sb.Append(arg).Append("=").Append(value);

                    firstElementAdded = true;
                }
            }

            return sb.ToString();
        }
    }
}
