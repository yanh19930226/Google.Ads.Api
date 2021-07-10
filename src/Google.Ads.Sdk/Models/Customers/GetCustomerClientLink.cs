using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Customers
{
    public class GetCustomerClientLinkRequest : GetRequest<GetCustomerClientLinkResponse>
    {

        public GetCustomerClientLinkRequest(string customerId, string clientCustomerId, string token, string developToken,string loginCustomerId) : base(token, developToken,loginCustomerId)
        {
            this.CustomerId = customerId;
            this.ClientCustomerId = clientCustomerId;
        }
        public string CustomerId { get; set; }
        public string ClientCustomerId { get; set; }
        public override string Url => "/customers/" + CustomerId + "/customerClientLinks/" + ClientCustomerId;

    }

    public class GetCustomerClientLinkResponse
    {
        public ManagerLinkStatus status { get; set; }
        public string clientCustomer { get; set; }
        public string managerLinkId { get; set; }
    }
}
