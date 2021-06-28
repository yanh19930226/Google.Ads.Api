using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Bases
{
    /// <summary>
    /// 搜索流请求类
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public abstract class SearchStreamRequest<V> : BaseRequest
    {
        /// <summary>
        ///搜索流请求类
        /// </summary>
        /// <param name="token">口令</param>
        /// <param name="developToken">开发者口令</param>
        /// <param name="query">sql语句</param>
        /// <param name="logingCustomerId">登入经理Id</param>
        /// <param name="linkedCustomerId">关联经理Id</param>
        public SearchStreamRequest(string token, string developToken, string query,string logingCustomerId=null,string linkedCustomerId=null) : base(token, developToken, logingCustomerId,linkedCustomerId)
        {
            this.Query = query;
        }

        public string Query { get; set; }

        public abstract string Url { get; }
    }

    /// <summary>
    /// 分页搜索请求类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SearchRequest<T> : BaseRequest
    {
        /// <summary>
        /// 分页搜索请求类
        /// </summary>
        /// <param name="token">口令</param>
        /// <param name="developToken">开发者口令</param>
        /// <param name="query">sql语句</param>
        /// <param name="pageSize">pageSize</param>
        /// <param name="pageToken">下一页口令</param>
        /// <param name="logingCustomerId">登入经理Id</param>
        /// <param name="linkedCustomerId">关联经理Id</param>
        public SearchRequest(string token, string developToken, string query, int pageSize = 10000, string pageToken = null, string logingCustomerId = null, string linkedCustomerId = null) : base(token, developToken, logingCustomerId, linkedCustomerId)
        {
            this.Query = query;
            this.pageSize = pageSize;
            this.pageToken = pageToken;
        }
        public string Query { get; set; }
        public int pageSize { get; set; }
        public string pageToken { get; set; }
        public abstract string Url { get; }
    }

    /// <summary>
    /// 搜索返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SearchResponse<T>
    {
        /// <summary>
        /// 结果集
        /// </summary>
        public List<T> results { get; set; }
        /// <summary>
        /// 下一页链接口令
        /// </summary>
        public string nextPageToken { get; set; } = null;
    }
}
