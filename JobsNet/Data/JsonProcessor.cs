using JobsNet.JobSearch.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JobsNet.Data
{
    public class JsonProcessor : DataProcessor
    {
        private JToken _tokens;

        public JsonProcessor(string jsonString)
        {
            GetTokens(jsonString);
        }

        private void GetTokens(string jsonString)
        {
            try
            {
                _tokens = JContainer.Parse(jsonString);
            }
            catch (JsonReaderException ex)
            {
                Debug.WriteLine("Error in {0} reading JSON: {1}", ex.Source, ex.Message);
            }
            catch (JsonSerializationException ex)
            {
                Debug.WriteLine("Serialization Error in {0}: {1}", ex.Source, ex.Message);
            }
            catch (JsonException ex)
            {
                Debug.WriteLine("Error in {0} with JSON: {1}", ex.Source, ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unspecified error: {0}", ex.Message);
            }
        }

        public override void FindRelevantNodes(string[] parentNodes, ResultNames resultNames)
        {
            foreach (string s in parentNodes)
                _tokens = _tokens.SelectToken(s);

            foreach (JToken token in _tokens)
            {
                JobNodeItem jobItem = new JobNodeItem(token, resultNames);
                _jobItems.Add(jobItem);
            }
        }
    }
}
