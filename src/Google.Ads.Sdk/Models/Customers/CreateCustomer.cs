using Google.Ads.Sdk.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Customers
{
    /// <summary>
    /// 创建广告账号model
    /// </summary>
    public class CreateCustomerModel
    {
        public string descriptiveName { get; set; }

        public string currencyCode { get; set; }

        public string timeZone { get; set; }

        public string trackingUrlTemplate { get; set; }

        public string finalUrlSuffix { get; set; }
       
    }

    /// <summary>
    /// 登入经理创建广告账号
    /// </summary>
    public class CreateCustomerClientRequest :BaseRequest
    {
        /// <summary>
        /// 登入经理创建广告账号
        /// </summary>
        /// <param name="model">广告账号</param>
        /// <param name="token">口令</param>
        /// <param name="developToken">开发者账号</param>
        /// <param name="loginCustomerId">登录经理Id</param>
        public CreateCustomerClientRequest(string loginCustomerId,CreateCustomerModel model,string token, string developToken) : base(token, developToken, loginCustomerId)
        {
            CustomerId = loginCustomerId;
            customerClient = model;
        }

        public CreateCustomerModel customerClient { get; set; }
        public string CustomerId { get; set; }
        public  string Url => $"/customers/{CustomerId}:createCustomerClient";
    }

    public class CreateCustomerClientResponse
    {
        public string resourceName { get; set; }

        public string invitationLink { get; set; }
    }
}
