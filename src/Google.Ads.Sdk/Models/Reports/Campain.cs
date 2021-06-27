using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Reports
{

    public class CampainAttribute 
    {
        public string resourceName { get; set; }
        public string name { get; set; }
        public string status { get; set; }
    }
    public class CampainMetric
    {
        public string impressions { get; set; }
        public string clicks { get; set; }
        public string ctr { get; set; }
        public string average_cpc { get; set; }
        public string cost_micros { get; set; }
    }
    public class CampainSegment
    {
        public string device { get; set; }
    }

    public class CampainReportSearchStreamRequest : SearchStreamRequest<SearchStreamResponse<CampainReportSearchStreamResponseModel>>
    {
        public CampainReportSearchStreamRequest(string customerId,string token,string developToken,string query) :base(token, developToken,query)
        {
            this.CustomerId = customerId;
        }
        public string CustomerId { get; set; }

        public override string Url => $"/customers/{CustomerId}/googleAds:searchStream";

    }

    public class CampainReportSearchStreamResponseModel
    {
        public CampainAttribute campaign { get; set; }

        public CampainMetric metric { get; set; }

        public CampainSegment segment { get; set; }
    }

    public class CampainReportSearchRequest : SearchRequest<SearchStreamResponse<CampainReportSearchResponseModel>>
    {
        public CampainReportSearchRequest(string customerId, string token, string developToken, string query) : base(token, developToken, query)
        {
            this.CustomerId = customerId;
        }
        public string CustomerId { get; set; }

        public override string Url => $"/customers/{CustomerId}/googleAds:search";

    }

    public class CampainReportSearchResponseModel
    {
        public CampainAttribute campaign { get; set; }

        public CampainMetric metric { get; set; }

        public CampainSegment segment { get; set; }
    }

}
