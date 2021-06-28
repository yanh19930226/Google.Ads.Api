using System.Net.Http;
using Newtonsoft.Json;
using Flurl.Http;
using Google.Ads.Sdk.Models.Bases;
using Google.Ads.Sdk.Models.Customers;
using Polly;
using Microsoft.Extensions.Logging;

namespace Google.Ads.Sdk
{
    public class GoogleClient
    {
        private HttpClient _client { get; }
        //private ISyncPolicy<HttpResponseMessage> _policy { get; }
        //private readonly ILogger<GoogleClient> _logger;
        public GoogleClient(/*ILogger<GoogleClient> logger, HttpClient client, ISyncPolicy<HttpResponseMessage> policy*/)
        {
            _client = new HttpClient();
        }

        /// <summary>
        /// 分页搜索
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public T SearchRequest<T>(SearchRequest<T> request)
        {
            var url = "https://googleads.googleapis.com/v8";

            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + request.Token);

            _client.DefaultRequestHeaders.Add("developer-token", request.DevelopToken);

            if (string.IsNullOrEmpty(request.LoginCustomerId) == false)
            {
                _client.DefaultRequestHeaders.Add("login-customer-id", request.LoginCustomerId);
            }

            if (string.IsNullOrEmpty(request.LinkedCustomerId) == false)
            {
                _client.DefaultRequestHeaders.Add("linked-customer-id", request.LinkedCustomerId);
            }

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(new { pageSize=request.pageSize, query = request.Query, pageToken=request.pageToken }));

            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage httpResponse = new HttpResponseMessage();

            httpResponse = _client.GetAsync(url).Result;

            var content = httpResponse.Content.ReadAsStringAsync().Result;

            T obj = JsonConvert.DeserializeObject<T>(content);

            return obj;
        }
        
        /// <summary>
        /// 搜索流
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public T SearchStreamRequest<T>(SearchStreamRequest<T> request)
        {
            var url = "https://googleads.googleapis.com/v8"+request.Url;

            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Add("ContentType", "application/json");

            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + request.Token);

            _client.DefaultRequestHeaders.Add("developer-token", request.DevelopToken);

            if (string.IsNullOrEmpty(request.LoginCustomerId) == false)
            {
                _client.DefaultRequestHeaders.Add("login-customer-id", request.LoginCustomerId);
            }

            if (string.IsNullOrEmpty(request.LinkedCustomerId) == false)
            {
                _client.DefaultRequestHeaders.Add("linked-customer-id", request.LinkedCustomerId);
            }

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(new { query = request.Query }));

            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage httpResponse = new HttpResponseMessage();

            httpResponse = _client.PostAsync(url, httpContent).Result;

            var content = httpResponse.Content.ReadAsStringAsync().Result;

            T obj = JsonConvert.DeserializeObject<T>(content);

            return obj;

        }

        /// <summary>
        /// Mutate
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public T MutateRequest<T>(MutateRequest<T> request)
        {
            var url = "https://googleads.googleapis.com/v8" + request.Url;

            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Add("ContentType", "application/json");

            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + request.Token);

            _client.DefaultRequestHeaders.Add("developer-token", request.DevelopToken);

            if (string.IsNullOrEmpty(request.LoginCustomerId) == false)
            {
                _client.DefaultRequestHeaders.Add("login-customer-id", request.LoginCustomerId);
            }

            if (string.IsNullOrEmpty(request.LinkedCustomerId) == false)
            {
                _client.DefaultRequestHeaders.Add("linked-customer-id", request.LinkedCustomerId);
            }

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(new {
                partialFailure=request.PartialFailure, 
                operations = request.Operations, 
                validateOnly=request.ValidateOnly,
                responseContentType=request.responseContentType
            }));

            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage httpResponse = new HttpResponseMessage();

            httpResponse = _client.PostAsync(url, httpContent).Result;

            var content = httpResponse.Content.ReadAsStringAsync().Result;

            T obj = JsonConvert.DeserializeObject<T>(content);

            return obj;
        }

        /// <summary>
        /// CreateCustomerClient(其他方法)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateCustomerClientResponse CreateCustomerClient(CreateCustomerClientRequest request)
        {
            var url = "https://googleads.googleapis.com/v8" + request.Url;

            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Add("ContentType", "application/json");

            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + request.Token);

            _client.DefaultRequestHeaders.Add("developer-token", request.DevelopToken);
           

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(new { customerClient = request.customerClient }));

            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage httpResponse = new HttpResponseMessage();

            httpResponse = _client.PostAsync(url, httpContent).Result;

            var content = httpResponse.Content.ReadAsStringAsync().Result;

            CreateCustomerClientResponse obj = JsonConvert.DeserializeObject<CreateCustomerClientResponse>(content);

            return obj;
        }
        
    }
}
