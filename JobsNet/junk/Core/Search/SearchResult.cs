using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.Core.Search
{
    public class SearchResult<T>
    {
        private Dictionary<T, string> _attributeValues = new Dictionary<T, string>();

        public SearchResult(IEnumerable<T> resultNames)
        {
            foreach (T t in resultNames)
                _attributeValues.Add(t, string.Empty);
        }

        public void SetValue(T name, string value)
        {
            if (_attributeValues.Keys.Contains(name))
                _attributeValues[name] = value;
        }

        public string GetValue(T name)
        {
            string result = string.Empty;
            if (_attributeValues.Keys.Contains(name))
                result = _attributeValues[name];
            return result;
        }
    }
}
