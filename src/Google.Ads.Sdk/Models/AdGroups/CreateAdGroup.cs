using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.AdGroups
{
    public enum AdGroupStatus
    {
        UNSPECIFIED,
        UNKNOWN,
        ENABLED,
        PAUSED,
        REMOVED
    }

    /// <summary>
    /// 创建广告组请求类
    /// </summary>
    public class CreateAdGroupModel 
    {
        public string name { get; set; }
        public AdGroupStatus status { get; set; }
        public string campaign { get; set; }
        public int cpcBidMicros { get; set; }
    }
    public class CreateAdGroupMutateRequest : MutateRequest<CreateAdGroupMutateResponse>
    {
        public CreateAdGroupMutateRequest(string customerId, CreateAdGroupModel model, string token, string developToken, List<Operation> operations, string loginCustomerId) : base(token, developToken, operations, loginCustomerId)
        {
            this.CustomerId = customerId;
            this.Model = model;
        }
        public string CustomerId { get; set; }
        public CreateAdGroupModel Model { get; set; }
        public override string Url => $"/customers/{CustomerId}/adGroups:mutate";
    }

    /// <summary>
    /// 创建广告组返回类
    /// </summary>
    public class CreateAdGroupResponseModel
    {

    }
    public class CreateAdGroupMutateResponse
    {
    }
}
