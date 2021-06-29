using Google.Ads.Sdk.Models.Ads;
using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.AdGroupAds
{
    public enum AdGroupAdStatus
    {
        UNSPECIFIED,
        UNKNOWN,
        ENABLED,
        PAUSED,
        REMOVED
    }
    public class CreateAdGroupAdModel
    {
        public string resourceName { get; set; }
        public AdGroupAdStatus status { get; set; }
        public UpdateAdModel ad { get; set; }
        public string adGroup { get; set; }
    }

    public class CreateAdGroupAdMutateRequest : MutateRequest<MutateResponse<CreateAdGroupAdResponseModel>>
    {
        public CreateAdGroupAdMutateRequest(string customerId, string token, string developToken, List<Operation> operations, string loginCustomerId) : base(token, developToken, operations, loginCustomerId)
        {
            this.CustomerId = customerId;
        }
        public string CustomerId { get; set; }
        public override string Url => $"/customers/{CustomerId}/adGroupAds:mutate";
    }

    public class CreateAdGroupAdResponseModel
    {
        public string resourceName { get; set; }
        public CreateAdGroupAdModel adGroupAd { get; set; }
    }
}
