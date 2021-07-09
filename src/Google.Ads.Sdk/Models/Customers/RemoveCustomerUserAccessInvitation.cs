using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Customers
{
    public class RemoveCustomerUserAccessInvitationRequest : OneMutateRequest
    {
        public RemoveCustomerUserAccessInvitationRequest(string customerId, string token, string developToken, Operation operation, string loginCustomerId) : base(token, developToken, operation, loginCustomerId)
        {
            this.CustomerId = customerId;
        }
        public string CustomerId { get; set; }

        public override string Url => $"/customers/{CustomerId}/customerUserAccessInvitations:mutate";
    }
}
