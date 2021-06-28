using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Campains
{
    public class RemoveCampainMutateRequest : MutateRequest<string>
    {
        public RemoveCampainMutateRequest(string customerId, string token, string developToken, List<Operation> operations) : base(token, developToken, operations)
        {
            CustomerId = customerId;
        }
        public string CustomerId { get; set; }
        public override string Url => "";
    }
}
