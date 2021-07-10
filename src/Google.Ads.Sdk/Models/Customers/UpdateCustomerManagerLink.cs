using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Customers
{
    public class UpdateCustomerManagerLinkModel
    {
        public ManagerLinkStatus status { get; set; }
        public string resourceName { get; set; }
    }

    public class UpdateCustomerManagerLinkRequest : MutateRequest<MutateResponse<string>>
    {
        public UpdateCustomerManagerLinkRequest(string customerId,string clientCustomerId, string token, string developToken, List<Operation> operations, string loginCustomerId) : base(token, developToken, operations, loginCustomerId)
        {
            this.CustomerId = customerId;
            this.ClientCustomerId = clientCustomerId;
        }
        public string CustomerId { get; set; }
        public string ClientCustomerId { get; set; }
        public override string Url => "/customers/" + CustomerId + "/customerClientLinks/" + ClientCustomerId;
    }
}
