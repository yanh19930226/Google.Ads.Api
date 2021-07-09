using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Google.Ads.Sdk.Models.Customers
{
    public class CustomerUserAccessRequest : GetRequest<CustomerUserAccessResponse>
    {
        public CustomerUserAccessRequest(string resourceName, string token, string developToken) : base(token, developToken)
        {
            this.ResourceName = resourceName;
        }
        public string ResourceName { get; set; }
        public override string Url => ResourceName;
    }
    public class CustomerUserAccessResponse
    {
        public string user_id { get; set; }
        public string email_address { get; set; }
        public string access_role { get; set; }
        public string access_creation_date_time { get; set; }
        public string inviter_user_email_address { get; set; }
    }
}
