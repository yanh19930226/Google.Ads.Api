using Google.Ads.GoogleAds;
using Google.Ads.GoogleAds.Config;
using Google.Ads.GoogleAds.Lib;
using Google.Ads.GoogleAds.V7.Errors;
using Google.Ads.GoogleAds.V7.Resources;
using Google.Ads.GoogleAds.V7.Services;
using Google.Ads.Sdk;
using Google.Ads.Sdk.Models;
using Google.Ads.Sdk.Models.Customers;
using Google.Ads.Sdk.Models.Reports;
using System;
using System.Collections.Generic;

namespace Google.Ads.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //string developerToken = "Fu8l4LAdiKG9BLBPsLB3uA";
            //string oAuth2clientId = "298324624669-kachgof1usnvgi9lc75f11fct1348met.apps.googleusercontent.com";
            //string oAuth2Secret = "FnwDNLJt_Rqf_-CM3YjO8F6c";
            //string oAuth2RefreshToken = "1//0d95VNNbjByVjCgYIARAAGA0SNwF-L9IrP7aZsFW6uJbTiLZDRGPtnsdvMESwLSLktrQ0qsRokRlWkeD2Vkrp3z75B2XETwoA1Vw";
            ////long loginCustomerId = long.Parse("INSERT_LOGIN_CUSTOMER_ID_HERE");

            //GoogleAdsConfig googleAdsConfig = new GoogleAdsConfig()
            //{
            //    DeveloperToken = developerToken,
            //    //LoginCustomerId = loginCustomerId.ToString(),
            //    OAuth2ClientId = oAuth2clientId,
            //    OAuth2ClientSecret = oAuth2Secret,
            //    OAuth2RefreshToken = oAuth2RefreshToken,
            //};

            //GoogleAdsClient googleAdsClient = new GoogleAdsClient(googleAdsConfig);

            //GetCampaigns(googleAdsClient, 2047682244);

            GoogleClient client = new GoogleClient();

            #region Search


            string query1 = @"SELECT
                                      campaign.name,
                                      campaign.status,
                                      segments.device,
                                      metrics.impressions,
                                      metrics.clicks,
                                      metrics.ctr,
                                      metrics.average_cpc,
                                      metrics.cost_micros
                                    FROM campaign
                                    WHERE segments.date DURING LAST_30_DAYS";

            string query = @"SELECT
                                      campaign.name,
                                      campaign.status
                                    FROM campaign";

            var accessToken = "ya29.a0AfH6SMAK8Ta7u1_8nQxKwb3iGJ9MZi105DnFKQAew2evGMBDkOF1U697KwH6tFb4-OgllSLZIY-Xk5B_ZiPFx69L2JTMh4fXLVqcMLIa-_7ZveFORa10D8e6qMxDTtusacg6_EHHpmYCe27lMe6vQEfaKTlG";

            CampainReportSearchStreamRequest req = new CampainReportSearchStreamRequest("9596133160", accessToken, "Fu8l4LAdiKG9BLBPsLB3uA", query);

            var res=client.SearchStreamRequest(req);

            System.Console.WriteLine(res.ToString());

            //CampainReportSearchRequest campainReportSearchRequest = new CampainReportSearchRequest("", "", "", "");

            //client.SearchRequest(campainReportSearchRequest);

            #endregion

            //List<Operation> operations = new List<Operation>();

            //CustomerCreateOption customerCreateOption = new CustomerCreateOption();

            //CreateOperation<CustomerCreateOption> createOperation = new CreateOperation<CustomerCreateOption>(customerCreateOption);

            //operations.Add(createOperation);

            //CustomerCreateMutateRequest mutateCreate = new CustomerCreateMutateRequest("", operations);

            //client.MutateRequest(mutateCreate);

            //System.Console.WriteLine(req.query);

            var result = new Test(1, 2);

            System.Console.WriteLine(result.Res);

        }

        public static void CreateCustomer(GoogleAdsClient client, long managerCustomerId)
        {
            // Get the CustomerService.
            CustomerServiceClient customerService = client.GetService(Services.V7.CustomerService);

            Customer customer = new Customer()
            {
                DescriptiveName = $"Account created with CustomerService on '{DateTime.Now}'",

                // For a list of valid currency codes and time zones see this documentation:
                // https://developers.google.com/google-ads/api/reference/data/codes-formats#codes_formats.
                CurrencyCode = "USD",
                TimeZone = "America/New_York",

                // The below values are optional. For more information about URL
                // options see: https://support.google.com/google-ads/answer/6305348.
                TrackingUrlTemplate = "{lpurl}?device={device}",
                FinalUrlSuffix = "keyword={keyword}&matchtype={matchtype}&adgroupid={adgroupid}"
            };

            try
            {
                // Create the account.
                CreateCustomerClientResponse response = customerService.CreateCustomerClient(
                    managerCustomerId.ToString(), customer);

            }
            catch (GoogleAdsException e)
            {
                throw;
            }
        }

        public static void GetCampaigns(GoogleAdsClient client, long customerId)
        {
            // Get the GoogleAdsService.
            GoogleAdsServiceClient googleAdsService = client.GetService(
                Services.V7.GoogleAdsService);

            // Create a query that will retrieve all campaigns.
            string query = @"SELECT
                            campaign.id,
                            campaign.name,
                            campaign.network_settings.target_content_network
                        FROM campaign
                        ORDER BY campaign.id";

            try
            {
                // Issue a search request.
                googleAdsService.SearchStream(customerId.ToString(), query,
                    delegate (SearchGoogleAdsStreamResponse resp)
                    {
                        foreach (GoogleAdsRow googleAdsRow in resp.Results)
                        {
                            System.Console.WriteLine("Campaign with ID {0} and name '{1}' was found.",
                                googleAdsRow.Campaign.Id, googleAdsRow.Campaign.Name);
                        }
                    }
                );
            }
            catch (GoogleAdsException e)
            {

                System.Console.WriteLine("Failure:");
                System.Console.WriteLine($"Message: {e.Message}");
                System.Console.WriteLine($"Failure: {e.Failure}");
                System.Console.WriteLine($"Request ID: {e.RequestId}");
                throw;
            }
        }

        public class Test
        {
            public Test(int a, int b)
            {
                A = a;
                B = b;
                Res = Add();
            }
            public int Res { get; set; }
            public int A { get; set; }
            public int B { get; set; }
            private int Add()
            {
                return A + B;
            }
        }
    }
}
