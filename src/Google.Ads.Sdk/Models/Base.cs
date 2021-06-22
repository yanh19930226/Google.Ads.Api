using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models
{
    public abstract class BaseRequest<T, K>
    {
        public BaseRequest(string token,string developToken)
        {
            this.Token = token;
            this.DevelopToken = developToken;
        }
        public string Token { get; set; }

        public string DevelopToken { get; set; }

        public abstract string Url { get; }
    }

    public class SearchRequest
    {
        public int query { get; set; }
        public int pageSize { get; set; }

        public int pageToken { get; set; }
    }
    public class SearchStreamRequest
    {
        public int query { get; set; }
        
    }

    public class MutateRequest
    {

    }

    public class Operation<T>
    {
        
    }
}
