using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Customers
{
    public class CreateCustomerModel
    {
        public string descriptiveName { get; set; }

        public string currencyCode { get; set; }

        public string timeZone { get; set; }

        public string trackingUrlTemplate { get; set; }

        public string finalUrlSuffix { get; set; }
       
    }

    public class CreateCustomerMutateRequest : MutateRequest
    {
        public CreateCustomerMutateRequest(string customerId, string token, string developToken, List<Operation> operations) :base(token, developToken, operations)
        {
            CustomerId = customerId;
        }
        public string CustomerId { get; set; }
        public override string Url => $"/customers/{CustomerId}:createCustomerClient";
    }


    public class CreateCustomerClientRequest :BaseRequest
    {
        public CreateCustomerClientRequest(string customerId, CreateCustomerModel model,string token, string developToken) : base(token, developToken)
        {
            CustomerId = customerId;
            customerClient = model;
        }

        public CreateCustomerModel customerClient { get; set; }
        public string CustomerId { get; set; }
        public  string Url => $"/customers/{CustomerId}:createCustomerClient";
    }
}
