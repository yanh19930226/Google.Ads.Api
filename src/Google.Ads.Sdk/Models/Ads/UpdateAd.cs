using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Ads
{
    public class ExpandedTextAdInfo
    {
        public string headlinePart1 { get; set; }
        public string headlinePart2 { get; set; }
        public string description { get; set; }
        public string path1 { get; set; }
        public string path2 { get; set; }
    }

    public class UpdateAdModel 
    {
        public ExpandedTextAdInfo expandedTextAd { get; set; }
        public List<string> finalUrls { get; set; }
    }

    public class UpdateAdMutateRequest : MutateRequest<MutateResponse<UpdateAdResponseModel>>
    {
        public UpdateAdMutateRequest(string customerId,  string token, string developToken, List<Operation> operations, string loginCustomerId) : base(token, developToken, operations, loginCustomerId)
        {
            this.CustomerId = customerId;
        }
        public string CustomerId { get; set; }
        public override string Url => $"/customers/{CustomerId}/ads:mutate";
    }

    /// <summary>
    /// 创建广告返回类
    /// </summary>
    public class UpdateAdResponseModel
    {
        public string resourceName { get; set; }
        public UpdateAdModel ad { get; set; }
    }
}
