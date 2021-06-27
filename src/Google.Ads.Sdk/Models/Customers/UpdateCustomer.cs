using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Customers
{

    public class UpdateCustomerModel
    {
        public string resourceName { get; set; }
        public string name { get; set; }

        public string age { get; set; }
    }

    public class UpdateCustomerMutateRequest : MutateRequest
    {
        public UpdateCustomerMutateRequest(string customerId, string token, string developToken, List<Operation> operations) : base(token, developToken, operations)
        {
            CustomerId = customerId;
        }
        public string CustomerId { get; set; }
        public override string Url => throw new NotImplementedException();
    }
}
