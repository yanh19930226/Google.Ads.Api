using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Customers
{
    public enum AccessInvitationStatus
    {
        UNSPECIFIED,
        UNKNOWN,
        PENDING,
        DECLINED,
        EXPIRED
    }
    public enum AccessRole
    {
        UNSPECIFIED,
        UNKNOWN,
        ADMIN,
        STANDARD,
        READ_ONLY,
        EMAIL_ONLY
    }
    public class CreateCustomerUserAccessInvitationModel
    {
        public AccessRole accessRole { get; set; }
        public string emailAddress { get; set; }
        public string creationDateTime { get; set; }
    }
    public class CreateCustomerUserAccessInvitationRequest : OneMutateRequest
    {
        public CreateCustomerUserAccessInvitationRequest(string customerId, string token, string developToken, Operation model, string loginCustomerId) : base(token, developToken, model, loginCustomerId)
        {
            this.CustomerId = customerId;
        }
        public string CustomerId { get; set; }
        public override string Url => $"/customers/{CustomerId}/customerUserAccessInvitations:mutate";
    }
}
