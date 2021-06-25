using Google.Ads.Sdk.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Flurl.Http;

namespace Google.Ads.Sdk
{
    public class GoogleClient
    {
        private HttpClient _client { get; }
        //private ISyncPolicy<HttpResponseMessage> _policy { get; }
        //private readonly ILogger<GoogleClient> _logger;
        public GoogleClient()
        {
            _client = new HttpClient();
        }

        public T SearchRequest<T>(SearchRequest<T> request)
        {
            var url = "https://googleads.googleapis.com/v8";

            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + request.Token);

            _client.DefaultRequestHeaders.Add("developer-token", request.DevelopToken);

            HttpResponseMessage httpResponse = new HttpResponseMessage();

            httpResponse = _client.GetAsync(url).Result;

            var content = httpResponse.Content.ReadAsStringAsync().Result;

            T obj = JsonConvert.DeserializeObject<T>(content);

            return obj;
        }
        public T SearchStreamRequest<T>(SearchStreamRequest<T> request)
        {
            var url = "https://googleads.googleapis.com/v8"+request.Url;

            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Add("ContentType", "application/json");

            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + request.Token);

            _client.DefaultRequestHeaders.Add("developer-token", request.DevelopToken);

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(new { query = request.Query }));

            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


            HttpResponseMessage httpResponse = new HttpResponseMessage();

            httpResponse = _client.PostAsync(url, httpContent).Result;

            var content = httpResponse.Content.ReadAsStringAsync().Result;

            T obj = JsonConvert.DeserializeObject<T>(content);

            return obj;

        }

        public T SearchStreamRequestTT<T>(SearchStreamRequest<T> request)
        {
            var host = "https://googleads.googleapis.com/v8";

            return $"{host}{request.Url}".WithHeaders(new { Authorization = "Bearer "+ request.Token, developer_token =request.DevelopToken })
                .PostJsonAsync(new
                {
                    query = request.Query
                })
                .ReceiveJson<T>().Result;

        }

        public void MutateRequest(MutateRequest mutateRequest)
        {

        }
    }
}
