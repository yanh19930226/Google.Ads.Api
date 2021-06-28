using Google.Ads.Sdk.Models.Bases;
using Google.Ads.Sdk.Models.CampainBudgets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.CampainBudgets
{

    public enum BudgetDeliveryMethod
    {
        UNSPECIFIED,
        UNKNOWN,
        STANDARD,
        ACCELERATED
    }

    /// <summary>
    /// 活动预算请求类
    /// </summary>
    public class CreateCampainBudgetModel
    {
        public string name { get; set; }
        public int amountMicros { get; set; }
        public BudgetDeliveryMethod deliveryMethod { get; set; }

    }
    public class CreateCampainBudgetMutateRequest : MutateRequest<CreateCampainBudgetResponse>
    {
        public CreateCampainBudgetMutateRequest(string customerId, CreateCampainBudgetModel model, string token, string developToken, List<Operation> operations, string loginCustomerId) : base(token, developToken, operations, loginCustomerId)
        {
            this.CustomerId = customerId;
            this.Model = model;
        }
        public string CustomerId { get; set; }
        public CreateCampainBudgetModel Model { get; set; }
        public override string Url => $"/customers/{CustomerId}/campaignBudgets:mutate";
    }

    /// <summary>
    /// 活动预算返回类
    /// </summary>
    public class CreateCampainBudgetResponseModel
    {
        public string resourceName { get; set; }
        public CreateCampainBudgetModel campaignBudget { get; set; }
    }
    public class CreateCampainBudgetResponse : MutateResponse<CreateCampainBudgetResponseModel>
    {

    }
}

