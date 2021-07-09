using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Bases
{
    /// <summary>
    ///请求类
    /// </summary>
    public class BaseRequest
    {
        /// <summary>
        /// 请求类
        /// </summary>
        /// <param name="token">口令</param>
        /// <param name="developToken">开发者口令</param>
        /// <param name="loginCustomerId">登入经理Id</param>
        /// <param name="linkedCustomerId">关联经理Id</param>
        public BaseRequest(string token, string developToken, string loginCustomerId=null, string linkedCustomerId=null)
        {
            this.Token = token;
            this.DevelopToken = developToken;
            this.LoginCustomerId = loginCustomerId;
            this.LinkedCustomerId = linkedCustomerId;
        }
        /// <summary>
        /// 口令
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 开发者口令
        /// </summary>
        public string DevelopToken { get; set; }
        /// <summary>
        /// 登入经理Id
        /// </summary>
        public string LoginCustomerId { get; set; }
        /// <summary>
        /// 关联经理Id
        /// </summary>
        public string LinkedCustomerId { get; set; }
    }

    /// <summary>
    ///请求类
    /// </summary>
    public abstract class GetRequest<T>
    {
        /// <summary>
        /// 请求类
        /// </summary>
        /// <param name="token">口令</param>
        /// <param name="developToken">开发者口令</param>
        /// <param name="loginCustomerId">登入经理Id</param>
        /// <param name="linkedCustomerId">关联经理Id</param>
        public GetRequest(string token, string developToken, string loginCustomerId = null, string linkedCustomerId = null)
        {
            this.Token = token;
            this.DevelopToken = developToken;
            this.LoginCustomerId = loginCustomerId;
            this.LinkedCustomerId = linkedCustomerId;
        }
        /// <summary>
        /// 口令
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 开发者口令
        /// </summary>
        public string DevelopToken { get; set; }
        /// <summary>
        /// 登入经理Id
        /// </summary>
        public string LoginCustomerId { get; set; }
        /// <summary>
        /// 关联经理Id
        /// </summary>
        public string LinkedCustomerId { get; set; }

        public abstract string Url { get; }
    }
}
