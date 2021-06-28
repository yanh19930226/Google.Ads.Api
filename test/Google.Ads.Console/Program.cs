using Google.Ads.Sdk;
using Google.Ads.Sdk.Models;
using Google.Ads.Sdk.Models.AdGroups;
using Google.Ads.Sdk.Models.Bases;
using Google.Ads.Sdk.Models.CampainBudgets;
using Google.Ads.Sdk.Models.Campains;
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

            var logincustomerId = "9596133160";
            var accessToken = "ya29.a0ARrdaM_cNVp5Hom05limuJ11qDX2EnOei_ZMXF0KwTX7jGqq7s6b6CNueZrqnYM-hkuXVLIVuAcN-dDxGKk5AlvtyZp6rLII9jwGXEkuI9rGINpk4_c7T9DE5Nx5DDSMorOhUnM2PllH5lNsT6O5Utw4r66e";
            var developToken = "Fu8l4LAdiKG9BLBPsLB3uA";

            #region CreateCustomer

            //CreateCustomerModel createModel = new CreateCustomerModel();
            //createModel.currencyCode = "USD";
            //createModel.descriptiveName = "apitest";
            //createModel.timeZone = "America/New_York";

            //var createCustomerClientRequest = new CreateCustomerClientRequest(customerId, createModel, accessToken, developToken);

            //var res = client.CreateCustomerClient(createCustomerClientRequest);

            //3833618729，5852967341

            #endregion

            #region CampainBudget

            //CreateCampainBudgetModel createCampainBudgetModel = new CreateCampainBudgetModel() {
            //    name = "yanhTestBudget",
            //    amountMicros= 500000,
            //    deliveryMethod=BudgetDeliveryMethod.STANDARD
            //};

            //var createCampainBudgetOperations = new MutateOperationsBuilder().ConfigureCreateOperation(new CreateOperation<CreateCampainBudgetModel>(createCampainBudgetModel)).Build();

            //var createCampainBudgetMutateRequest = new CreateCampainBudgetMutateRequest("3833618729", createCampainBudgetModel, accessToken, developToken, createCampainBudgetOperations, logincustomerId);

            //var createCampainBudgetRes = client.MutateRequest(createCampainBudgetMutateRequest);


            #endregion


            #region CreateCampain

            //CreateCampainModel createCampainModel = new CreateCampainModel()
            //{
            //    name = "test2",
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

            //var createCampainMutateRequest = new CreateCampainMutateRequest("3833618729", createCampainModel, accessToken, developToken, createCampainOperations, logincustomerId);

            //var createCampainRes = client.MutateRequest(createCampainMutateRequest);

            //System.Console.WriteLine(createCampainRes);

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

            #region CreateCampainAdGroup

            CreateAdGroupModel createAdGroupModel = new CreateAdGroupModel() { 
              name="testGroup",
              campaign= "customers/3833618729/campaigns/13693376620",
              cpcBidMicros= 10000000,
              status= AdGroupStatus.ENABLED
            };

            var createAdGroupOperations = new MutateOperationsBuilder().ConfigureCreateOperation(new CreateOperation<CreateAdGroupModel>(createAdGroupModel)).Build();

            var createAdGroupMutateRequest = new CreateAdGroupMutateRequest("3833618729", createAdGroupModel, accessToken, developToken, createAdGroupOperations, logincustomerId);

            var createAdGroupRes = client.MutateRequest(createAdGroupMutateRequest);

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
