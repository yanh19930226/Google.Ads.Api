using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Customers
{
    public class GetCustomerUserAccessInvitationRequest :  GetRequest<CustomerUserAccessInvitationResponse>
    {
        public GetCustomerUserAccessInvitationRequest(string customerId, string invitationId,string token, string developToken) : base(token, developToken)
        {
            this.CustomerId = customerId;
            this.InvitationId = invitationId;

        }
        public string CustomerId { get; set; }
        public string InvitationId { get; set; }

        public override string Url => "/customers/"+ CustomerId + "/customerUserAccessInvitations/"+ InvitationId;
    }

    public class CustomerUserAccessInvitationResponse
    {
        public string user_id { get; set; }
        public string email_address { get; set; }
        public string access_role { get; set; }
        public string access_creation_date_time { get; set; }
        public string inviter_user_email_address { get; set; }
    }
}
