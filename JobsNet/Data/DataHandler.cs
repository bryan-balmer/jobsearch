using JobsNet.JobSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.Data
{
    public class DataHandler
    {
        IDataProcessor _processor;

        public DataHandler(string data)
        {
            data = data.Trim();
            if ((data.StartsWith("{") && data.EndsWith("}")) ||
                data.StartsWith("[") && data.EndsWith("]"))
                _processor = new JsonProcessor(data);
            else if (data.StartsWith("<") && data.EndsWith(">"))
                _processor = new XmlProcessor(data);
            else
                throw new ArgumentException("Data for processing not valid or not supported.");
        }

        public IEnumerable<JobPosting> GetJobPostings(string data, string[] parentNodes, ResultNames resultNames)
        {
            List<JobPosting> jobPostings = new List<JobPosting>();

            _processor.FindRelevantNodes(parentNodes, resultNames);

            foreach (JobNodeItem item in _processor)
            {
                jobPostings.Add(item);
            }

            return jobPostings;
        }
    }
}
