using Google.Ads.GoogleAds;
using Google.Ads.GoogleAds.Config;
using Google.Ads.GoogleAds.Lib;
using Google.Ads.GoogleAds.V7.Errors;
using Google.Ads.GoogleAds.V7.Resources;
using Google.Ads.GoogleAds.V7.Services;
using Google.Ads.Sdk;
using Google.Ads.Sdk.Models;
using Google.Ads.Sdk.Models.Bases;
using Google.Ads.Sdk.Models.Customers;
using Google.Ads.Sdk.Models.Reports;
using System;
using System.Collections.Generic;
using CreateCustomerClientRequest = Google.Ads.Sdk.Models.Customers.CreateCustomerClientRequest;

namespace Google.Ads.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            GoogleClient client = new GoogleClient();



            var accessToken = "ya29.a0ARrdaM9zGPSQvTk5p9VGBexrv0IpOW5xTu037hDWghy2NTNXXGgKTtmrbF_vSDIz3nophD1vBFb7k-MxOEVZgSpZYZ1zVAA3MSNyjfVFnm_Gkoog3TPwiJDwDH_9FR0dk3KueS2tgBsSiy3sqW9eK-ZDHh8w";
            var developToken = "Fu8l4LAdiKG9BLBPsLB3uA";
            #region Search

            //string query1 = @"SELECT
            //                          campaign.name,
            //                          campaign.status,
            //                          segments.device,
            //                          metrics.impressions,
            //                          metrics.clicks,
            //                          metrics.ctr,
            //                          metrics.average_cpc,
            //                          metrics.cost_micros
            //                        FROM campaign
            //                        WHERE segments.date DURING LAST_30_DAYS";

            //string query = @"SELECT
            //                          campaign.name,
            //                          campaign.status
            //                        FROM campaign";


            //CampainReportSearchStreamRequest req = new CampainReportSearchStreamRequest("9596133160", accessToken, "Fu8l4LAdiKG9BLBPsLB3uA", query);

            //var res=client.SearchStreamRequest(req);



            //CampainReportSearchRequest campainReportSearchRequest = new CampainReportSearchRequest("", "", "", "");

            //client.SearchRequest(campainReportSearchRequest);

            #endregion

            #region Create
            CreateCustomerModel createModel = new CreateCustomerModel();
            createModel.currencyCode = "USD";
            createModel.descriptiveName = "apitest";
            createModel.timeZone = "America/New_York";

            //var createoperations = new MutateOperationsBuilder().ConfigureCreateOperation(new CreateOperation<CreateCustomerModel>(createModel)).Build();

            //CreateCustomerMutateRequest customerCreateMutateRequest = new CreateCustomerMutateRequest("9596133160",accessToken, developToken, createoperations);

            var createCustomerClient = new CreateCustomerClientRequest("9596133160", createModel, accessToken, developToken);

            //3833618729，5852967341

            var res = client.Post(createCustomerClient);

            //var res = client.MutateRequest(customerCreateMutateRequest);
            #endregion

            #region Update
            //UpdateCustomerModel updateModel = new UpdateCustomerModel();
            //updateModel.resourceName = "11";
            //updateModel.age = "11";
            //updateModel.name = "test";

            //var updateoperations = new MutateOperationsBuilder().ConfigureUpdateCreateOperation(new UpdateOperation<UpdateCustomerModel>(updateModel)).Build();
            //UpdateCustomerMutateRequest updateCustomerMutateRequest = new UpdateCustomerMutateRequest("", "", "", updateoperations);

            //var res = client.MutateRequest(updateCustomerMutateRequest);
            #endregion

            #region Remove

            //var removeoperations = new MutateOperationsBuilder().ConfigureRemoveOperation(new RemoveOperation() { remove = "" }).Build();
            //RemoveCustomerMutateRequest removeCustomerMutateRequest = new RemoveCustomerMutateRequest("", "", "", removeoperations);
            //var res = client.MutateRequest(removeCustomerMutateRequest);

            #endregion

            #region MultiOperation
            //var multiOperations = new MutateOperationsBuilder()
            //    .ConfigureCreateOperation(new CreateOperation<CreateCustomerModel>(createModel))
            //    .ConfigureUpdateCreateOperation(new UpdateOperation<UpdateCustomerModel>(updateModel))
            //    .ConfigureRemoveOperation(new RemoveOperation() { remove = "" }).Build();
            //var res = client.MutateRequest(removeCustomerMutateRequest);
            #endregion

            System.Console.WriteLine(res.ToString());

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
