using JobsNet.JobSearch.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.Data
{
    public abstract class DataProcessor : IDataProcessor
    {
        protected int _position = 0;
        protected List<JobNodeItem> _jobItems = new List<JobNodeItem>();

        public abstract void FindRelevantNodes(string[] parentNodes, ResultNames resultNames);

        public object Current
        {
            get { return _jobItems.ElementAt(_position); }
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _jobItems.Count());
        }

        public void Reset()
        {
            _position = 0;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
    }
}
