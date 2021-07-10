using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Customers
{
    public class UpdateCustomerClientLinkModel
    {
        public ManagerLinkStatus status { get; set; }
        //public string clientCustomer { get; set; }
        public string resourceName { get; set; }
    }

    public class UpdateCustomerClientLinkRequest : OneMutateRequest
    {
        public UpdateCustomerClientLinkRequest(string customerId, string token, string developToken, Operation model, string loginCustomerId) : base(token, developToken, model, loginCustomerId)
        {
            this.CustomerId = customerId;
        }
        public string CustomerId { get; set; }
        public override string Url => "/customers/" + CustomerId + "/customerClientLinks:mutate";
    }
}
