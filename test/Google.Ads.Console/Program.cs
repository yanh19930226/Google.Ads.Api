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
using System;
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

            var accessToken = "ya29.a0ARrdaM_QamycFWTrhM9JsgqRhDY2F40Lrdsx3zsxcItrsEcJowgvUFf70u_Ayx9Edt0pki2uls8X_rIPExocWGlguRVyxNACsNDP-FCxepipdxtQ9ONEtfqMwe140D26gNWUCIwBGvd4bjysgwvRBkUmgJ_u";
            var developToken = "Fu8l4LAdiKG9BLBPsLB3uA";

            #region CreateCustomer

            //CreateCustomerModel createModel = new CreateCustomerModel();
            //createModel.currencyCode = "USD";
            //createModel.descriptiveName = "apitest11133ii";
            //createModel.timeZone = "America/New_York";

            //var createCustomerClientRequest = new CreateCustomerClientRequest(logincustomerId, createModel, accessToken, developToken);

            //var res = client.CreateCustomerClient(createCustomerClientRequest);

            //3833618729，5852967341

            #endregion

            #region CampainBudget

            //CreateCampainBudgetModel createCampainBudgetModel = new CreateCampainBudgetModel()
            //{
            //    name = "yanhTestBudgetsfssfsyuyukl",
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

            //CreateAdGroupAdModel createAdGroupAdModel = new CreateAdGroupAdModel()
            //{
            //    adGroup = "customers/3833618729/adGroups/129830830488",
            //    status = AdGroupAdStatus.PAUSED,
            //    ad = new UpdateAdModel()
            //    {
            //        finalUrls = new List<string>() { "http://www.yanhfundf.com" },
            //        expandedTextAd = new ExpandedTextAdInfo
            //        {
            //            description = "descriptionddd",
            //            headlinePart1 = "headlinePart1d",
            //            headlinePart2 = "headlinePart2d",
            //            path1 = "path1dd",
            //            path2 = "path2ddd"
            //        }
            //    }
            //};

            //var createAdGroupAdOperations = new MutateOperationsBuilder().ConfigureCreateOperation(new CreateOperation<CreateAdGroupAdModel>(createAdGroupAdModel)).Build();

            //var createAdGroupAdMutateRequest = new CreateAdGroupAdMutateRequest("3833618729", accessToken, developToken, createAdGroupAdOperations, logincustomerId);

            //var createAdGroupadRes = client.MutateRequest(createAdGroupAdMutateRequest);

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

            #region ListAccessibleCustomers
            //ListAccessibleCustomersRequest listAccessibleCustomersRequest = new ListAccessibleCustomersRequest(accessToken,developToken);

            //var res = client.ListAccessibleCustomers(listAccessibleCustomersRequest); 
            #endregion

            #region OneMutateRequest CreateCustomerUserAccessInvitation

            //CreateCustomerUserAccessInvitationModel model = new CreateCustomerUserAccessInvitationModel()
            //{
            //    accessRole = AccessRole.ADMIN,
            //    emailAddress = "elston159hzlp0@mail.com",
            //    creationDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            //};

            //var operation = new CreateOperation<CreateCustomerUserAccessInvitationModel>(model);

            //CreateCustomerUserAccessInvitationRequest createCustomerUserAccessInvitationRequest = new CreateCustomerUserAccessInvitationRequest("9596133160", accessToken, developToken, operation, "9596133160");

            //var res = client.OneMutateRequest(createCustomerUserAccessInvitationRequest);

            //System.Console.WriteLine(res.ToString());

            #endregion

            #region GetCustomerUserAccessInvitationRequest

            GetCustomerUserAccessInvitationRequest getCustomerUserAccessInvitationRequest = new GetCustomerUserAccessInvitationRequest("9596133160", "77885268", accessToken, developToken);

            var res = client.GetRequest(getCustomerUserAccessInvitationRequest);

            System.Console.WriteLine(res.ToString());

            #endregion

            #region RemoveCustomerUserAccessInvitationRequest

            //var operation = new RemoveOperation() { remove= "/customers/9596133160/customerUserAccessInvitations/77885268" };

            //RemoveCustomerUserAccessInvitationRequest removeCustomerUserAccessInvitationRequest = new RemoveCustomerUserAccessInvitationRequest("9596133160", accessToken, developToken,operation,null);

            //var res = client.OneMutateRequest(removeCustomerUserAccessInvitationRequest);

            //System.Console.WriteLine(res.ToString());

            #endregion

            #region CustomerUserAccessRequest

            //CustomerUserAccessRequest CustomerUserAccessRequest = new CustomerUserAccessRequest("/customers/3833618729/customerUserAccesses/13693376620", accessToken, developToken);

            //var res = client.GetRequest(CustomerUserAccessRequest);

            //System.Console.WriteLine(res.ToString());

            #endregion

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
