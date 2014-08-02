using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JobsNet.SiteSearch.Arguments
{
    public interface IArgument
    {

    }

    public class Argument<T>
    {
        public string Name { get; set; }
        public T Value { get; set; }

        public Argument(string name, T value) 
        {
            Name = name;
            Value = value;
        }
    }
}
