using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Campains
{
    public enum CampainStatus
    {
        UNSPECIFIED,
        UNKNOWN,
        ENABLED,
        PAUSED,
        REMOVED
    }
    public enum AdvertisingChannelType
    {
        UNSPECIFIED,
        UNKNOWN,
        SEARCH,
        DISPLAY,
        SHOPPING,
        HOTEL,
        VIDEO,
        MULTI_CHANNEL,
        LOCAL,
        SMART
    }

    public class NetworkSettings
    {
        public bool targetGoogleSearch { get; set; }
        public bool targetSearchNetwork { get; set; }
        public bool targetContentNetwork { get; set; }
        public bool targetPartnerSearchNetwork { get; set; }
    }
    public class ManualCpc
    {
        public bool enhancedCpcEnabled { get; set; }
        
    }

    /// <summary>
    /// 创建活动
    /// </summary>
    public class CreateCampainModel
    {
          public string name { get; set; }
          public CampainStatus status { get; set; }
          public AdvertisingChannelType advertisingChannelType { get; set; }
          public string campaignBudget { get; set; }
          public ManualCpc manualCpc { get; set; }
          public NetworkSettings networkSettings { get; set; }
         public string startDate { get; set; }
         public string endDate { get; set; }
    } 

    public class CreateCampainMutateRequest : MutateRequest<MutateResponse<CreateCampainResponseModel>>
    {
        public CreateCampainMutateRequest(string customerId,string token, string developToken, List<Operation> operations,string loginCustomerId) :base(token, developToken, operations,loginCustomerId)
        {
            this.CustomerId = customerId;
        }
        public string CustomerId { get; set; }
        public override string Url => $"/customers/{CustomerId}/campaigns:mutate";
    }

    /// <summary>
    /// 创建活动返回类
    /// </summary>
    public class CreateCampainResponseModel
    {
        public string resourceName { get; set; }
        public CreateCampainModel campaign { get; set; }
    }
}
