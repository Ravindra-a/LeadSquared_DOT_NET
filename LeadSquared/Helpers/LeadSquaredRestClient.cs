using LeadSquared.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LeadSquared.Helpers
{
    /// <summary>
    /// REstClient Wrapper to push data to LeadSquared API
    /// </summary>
    public class LeadSquaredRestClient
    {
        private readonly RestClient _client;
        private string _apicontrollername;

        private readonly string _url = ConfigurationManager.AppSettings["leadsquaredbaseurl"]; //https://api.leadsquared.com/v2/
        private readonly string accessKey = ConfigurationManager.AppSettings["leadSquaredAccessKey"]; //<YOUR LEADSQUARED ACCESS KEY>
        private readonly string secretKey = ConfigurationManager.AppSettings["leadsquaredSecret"]; //<YOUR LEADSQUARED SECRET>

        public LeadSquaredRestClient(string apicontrollername)
        {
            _apicontrollername = apicontrollername;
            _client = new RestClient(_url);
        }

        /// <summary>
        /// Method to push data to LeadSquared
        /// </summary>
        /// <param name="leadJsonString"></param>
        /// <returns></returns>
        public Boolean AddLead(List<LeadParameter> leadJsonString)
        {
            try
            {
                var request = new RestRequest(_apicontrollername + "?accessKey=" + accessKey + "&secretKey=" + secretKey, Method.POST) { RequestFormat = DataFormat.Json };
                request.AddBody(leadJsonString);
                var response = _client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                //log the error and return
                return false;
            }
            catch
            {
                throw;
            }

        }
    }
}
