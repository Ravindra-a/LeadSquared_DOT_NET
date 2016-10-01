using LeadSquared.Helpers;
using LeadSquared.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadSquared
{
    class Program
    {
        static void Main(string[] args)
        {
            LeadSquaredRestClient leadSquaredRestClient = new LeadSquaredRestClient(ConfigurationManager.AppSettings["leadsquaredcreateleadURL"]); //LeadManagement.svc/Lead.Create
            List<LeadParameter> model = new List<LeadParameter>();
            model.Add(new LeadParameter { Attribute = "EmailAddress", Value = "test@test.com" });
            model.Add(new LeadParameter { Attribute = "Phone", Value = "1234567890" });
            leadSquaredRestClient.AddLead(model);
        }
    }


}
