using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace APIAssignment.Pages
{
    public class GenericAPI_Fucntions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Below method is used to get rest response
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public JObject PostAPI(string apiKey)
        {
            JObject parsedContent   = null;
            string ServiceURI       = "http://api.intigral-ott.net/popcorn-api-rs-7.9.10/v1/promotions?apikey=" + apiKey;
            try
            {
                var restClient      = new RestClient(ServiceURI);
                var restRequest     = new RestRequest(Method.GET);
                var restResponse    = restClient.Execute(restRequest);
                ScenarioContext.Current["restResponse"] = restResponse;

                parsedContent       = JObject.Parse(restResponse.Content);
                ScenarioContext.Current["response"] = parsedContent;
            }
            catch (Exception e)
            {
                log.Error("Unable to make request " + e.Message);
            }
            return parsedContent;
        }

        /// <summary>
        /// Below method is used to get all the headers with values from the response
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public Dictionary<string,string> GetHeaderContent(IRestResponse response)
        {
            Dictionary<string, string> HeadersList = new Dictionary<string, string>();

            foreach (var item in response.Headers)
            {
                string[] keyValuePairs = item.ToString().Split('=');
                HeadersList.Add(keyValuePairs[0], keyValuePairs[1]);
            }
            return HeadersList;
        }

        
    }
}
