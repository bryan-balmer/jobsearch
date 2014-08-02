using JobsNet.JobSearch.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.Data
{
    public interface IDataProcessor : IEnumerator, IEnumerable
    {
        void FindRelevantNodes(string[] parentNodes, ResultNames resultNames);
    }
}
