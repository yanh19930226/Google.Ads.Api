using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Customers
{
    public class ListAccessibleCustomersRequest : GetRequest<ListAccessibleCustomersResponse>
    {
        public ListAccessibleCustomersRequest( string token, string developToken) : base(token, developToken)
        {

        }
        public override string Url => $"/customers:listAccessibleCustomers";
    }

    public class ListAccessibleCustomersResponse
    {
        public List<string> resourceNames { get; set; }

    }
}
