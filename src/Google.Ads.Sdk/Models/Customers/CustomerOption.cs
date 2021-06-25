using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Customers
{
    public class CustomerCreateOption
    {
        public string DescriptiveName { get; set; }

        public string CurrencyCode { get; set; }

        public string TimeZone { get; set; }

        public string TrackingUrlTemplate { get; set; }

        public string FinalUrlSuffix { get; set; }
       
    }

    public class CustomerCreateMutateRequest : MutateRequest
    {
        public CustomerCreateMutateRequest(string customerId,List<Operation> CreateOperation) :base(CreateOperation)
        {
            CustomerId = customerId;
        }
        public string CustomerId { get; set; }
        public override string Url => $"/customers/{CustomerId}/campaigns:mutate";
    }
}
