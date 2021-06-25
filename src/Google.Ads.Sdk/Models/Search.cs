using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models
{
    public abstract class SearchStreamRequest<V> : BaseRequest
    {
        public SearchStreamRequest(string token, string developToken, string query) : base(token, developToken)
        {
            this.Query = query;
        }

        public string Query { get; set; }

        public abstract string Url { get; }
    }

    public class SearchStreamResponse<T>
    {
        public List<T> results { get; set; }
    }

    public abstract class SearchRequest<T> : BaseRequest
    {
        public SearchRequest(string token, string developToken, string query, int pageSize = 10000, string pageToken = null) : base(token, developToken)
        {
            this.query = query;
            this.pageSize = pageSize;
            this.pageToken = pageToken;
        }
        public string query { get; set; }
        public int pageSize { get; set; }
        public string pageToken { get; set; }
        public abstract string Url { get; }
    }

    public class SearchResponse<T>
    {
        public List<T> results { get; set; }

        public string nextPageToken { get; set; } = null;
    }
}
