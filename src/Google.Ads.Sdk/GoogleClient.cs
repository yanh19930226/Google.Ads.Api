using Polly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Google.Ads.Sdk
{
    public class GoogleClient
    {

        private HttpClient _client { get; }
        private ISyncPolicy<HttpResponseMessage> _policy { get; }
        //private readonly ILogger<GoogleClient> _logger;
        public GoogleClient()
        {

        }
        public void Get()
        {

        }


        public void Post()
        {

        }
    }
}
