using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Reports
{
    /// <summary>
    /// 属性
    /// </summary>
    public class CampainAttribute 
    {
        public string resourceName { get; set; }
        public string name { get; set; }
        public string status { get; set; }
    }
    /// <summary>
    /// 指标
    /// </summary>
    public class CampainMetric
    {
        public string impressions { get; set; }
        public string clicks { get; set; }
        public string ctr { get; set; }
        public string average_cpc { get; set; }
        public string cost_micros { get; set; }
    }
    /// <summary>
    /// 分组
    /// </summary>
    public class CampainSegment
    {
        public string device { get; set; }
    }

    /// <summary>
    /// 广告活动搜索流
    /// </summary>
    public class CampainReportSearchStreamRequest : SearchStreamRequest<SearchResponse<CampainReportSearchResponseModel>>
    {
        public CampainReportSearchStreamRequest(string customerId,string token,string developToken,string query) :base(token, developToken,query)
        {
            this.CustomerId = customerId;
        }
        public string CustomerId { get; set; }

        public override string Url => $"/customers/{CustomerId}/googleAds:searchStream";

    }

    /// <summary>
    /// 广告活动分页搜索
    /// </summary>
    public class CampainReportSearchRequest : SearchRequest<SearchResponse<CampainReportSearchResponseModel>>
    {
        public CampainReportSearchRequest(string customerId, string token, string developToken, string query) : base(token, developToken, query)
        {
            this.CustomerId = customerId;
        }
        public string CustomerId { get; set; }

        public override string Url => $"/customers/{CustomerId}/googleAds:search";

    }

    /// <summary>
    /// 广告活动搜索返回结果
    /// </summary>
    public class CampainReportSearchResponseModel
    {
        public CampainAttribute campaign { get; set; }

        public CampainMetric metric { get; set; }

        public CampainSegment segment { get; set; }
    }

}
