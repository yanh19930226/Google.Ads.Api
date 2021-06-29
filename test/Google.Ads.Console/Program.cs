using Google.Ads.Sdk;
using Google.Ads.Sdk.Models.AdGroupAds;
using Google.Ads.Sdk.Models.AdGroups;
using Google.Ads.Sdk.Models.Ads;
using Google.Ads.Sdk.Models.Bases;
using Google.Ads.Sdk.Models.CampainBudgets;
using Google.Ads.Sdk.Models.Campains;
using Google.Ads.Sdk.Models.Customers;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using CreateCustomerClientRequest = Google.Ads.Sdk.Models.Customers.CreateCustomerClientRequest;

namespace Google.Ads.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var loggerMock = new Mock<ILogger<GoogleClient>>();

            var policyloggerMock = new Mock<ILogger<GoogleClientPolly>>();

            var policy = new GoogleClientPolly(policyloggerMock.Object).CreatePolly();

            GoogleClient client = new GoogleClient(loggerMock.Object, new HttpClient(), policy);

            var logincustomerId = "9596133160";
            var accessToken = "ya29.a0ARrdaM81u2urd6WaMdjg2kchO30AOzifbVTO-0bPOP5mjoIzegIa4RkrB_mJKswYGJUy35r3NmKl0iBYxHLla1jYpqBlInAAE3Bl0QVUG1gGc-8nQmwgyflvSadFqwWuLRSBxDeEvmLjMNsESnSTjAPkl-Ch";
            var developToken = "Fu8l4LAdiKG9BLBPsLB3uA";

            #region CreateCustomer

            //CreateCustomerModel createModel = new CreateCustomerModel();
            //createModel.currencyCode = "USD";
            //createModel.descriptiveName = "apitest11133";
            //createModel.timeZone = "America/New_York";

            //var createCustomerClientRequest = new CreateCustomerClientRequest(logincustomerId, createModel, accessToken, developToken);

            //var res = client.CreateCustomerClient(createCustomerClientRequest);

            //3833618729，5852967341

            #endregion

            #region CampainBudget

            //CreateCampainBudgetModel createCampainBudgetModel = new CreateCampainBudgetModel()
            //{
            //    name = "yanhTestBudgetsfssfsyuyu",
            //    amountMicros = "500000",
            //    deliveryMethod = BudgetDeliveryMethod.STANDARD
            //};

            //var createCampainBudgetOperations = new MutateOperationsBuilder().ConfigureCreateOperation(new CreateOperation<CreateCampainBudgetModel>(createCampainBudgetModel)).Build();

            //var createCampainBudgetMutateRequest = new CreateCampainBudgetMutateRequest("3833618729", accessToken, developToken, createCampainBudgetOperations, logincustomerId);

            //var createCampainBudgetRes = client.MutateRequest(createCampainBudgetMutateRequest);


            #endregion

            #region CreateCampain

            //CreateCampainModel createCampainModel = new CreateCampainModel()
            //{
            //    name = "test355",
            //    status = CampainStatus.PAUSED,
            //    advertisingChannelType = AdvertisingChannelType.SEARCH,
            //    campaignBudget = "customers/3833618729/campaignBudgets/9011268205",
            //    manualCpc = new ManualCpc() { enhancedCpcEnabled = true },
            //    startDate = "2021-06-29",
            //    endDate = "2021-09-29",
            //    networkSettings = new NetworkSettings()
            //    {
            //        targetGoogleSearch = true,
            //        targetSearchNetwork = true,
            //        targetContentNetwork = false,
            //        targetPartnerSearchNetwork = false,
            //    }
            //};

            //var createCampainOperations = new MutateOperationsBuilder().ConfigureCreateOperation(new CreateOperation<CreateCampainModel>(createCampainModel)).Build();

            //var createCampainMutateRequest = new CreateCampainMutateRequest("3833618729", accessToken, developToken, createCampainOperations, logincustomerId);

            //var createCampainRes = client.MutateRequest(createCampainMutateRequest);

            #endregion

            #region CreateCampainAdGroup

            //CreateAdGroupModel createAdGroupModel = new CreateAdGroupModel()
            //{
            //    name = "testGroup11yfddss",
            //    campaign = "customers/3833618729/campaigns/13693376620",
            //    cpcBidMicros = 10000000,
            //    status = AdGroupStatus.ENABLED
            //};

            //var createAdGroupOperations = new MutateOperationsBuilder().ConfigureCreateOperation(new CreateOperation<CreateAdGroupModel>(createAdGroupModel)).Build();

            //var createAdGroupMutateRequest = new CreateAdGroupMutateRequest("3833618729", accessToken, developToken, createAdGroupOperations, logincustomerId);

            //var createAdGroupRes = client.MutateRequest(createAdGroupMutateRequest);

            #endregion

            #region CreateCampainAdGroupAd

            CreateAdGroupAdModel createAdGroupAdModel = new CreateAdGroupAdModel()
            {
                adGroup = "customers/3833618729/adGroups/129830830488",
                status = AdGroupAdStatus.PAUSED,
                ad = new UpdateAdModel()
                {
                    finalUrls = new List<string>() { "http://www.yanhfundf.com" },
                    expandedTextAd = new ExpandedTextAdInfo
                    {
                        description = "descriptionddd",
                        headlinePart1 = "headlinePart1d",
                        headlinePart2 = "headlinePart2d",
                        path1 = "path1dd",
                        path2 = "path2ddd"
                    }
                }
            };

            var createAdGroupAdOperations = new MutateOperationsBuilder().ConfigureCreateOperation(new CreateOperation<CreateAdGroupAdModel>(createAdGroupAdModel)).Build();

            var createAdGroupAdMutateRequest = new CreateAdGroupAdMutateRequest("3833618729", accessToken, developToken, createAdGroupAdOperations, logincustomerId);

            var createAdGroupadRes = client.MutateRequest(createAdGroupAdMutateRequest);

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

            #region SearchCampaign

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

            //System.Console.WriteLine(res.ToString());

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
