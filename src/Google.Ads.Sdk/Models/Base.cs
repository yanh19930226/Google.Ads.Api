using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Google.Ads.Sdk.Models
{
    public class BaseAttribute
    {
        internal string resourceName { get; set; }
    }

    public class BaseRequest
    {
        public BaseRequest(string token, string developToken, string loginCustomerId = null, string linkedCustomerId = null)
        {
            this.Token = token;
            this.DevelopToken = developToken;
            this.LoginCustomerId = loginCustomerId;
            this.LinkedCustomerId = linkedCustomerId;
        }

        public string Token { get; set; }
        public string DevelopToken { get; set; }
        public string LoginCustomerId { get; set; }
        public string LinkedCustomerId { get; set; }

    }
    
}
