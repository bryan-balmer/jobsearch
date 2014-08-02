using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.Web
{
    public interface IDataRequest
    {
        Task<string> GetData(string dataSource);
    }
}
