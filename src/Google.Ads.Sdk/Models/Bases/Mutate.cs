using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Bases
{
    /// <summary>
    /// Mutate请求类
    /// </summary>
    public abstract class MutateRequest<T> : BaseRequest
    {
        /// <summary>
        /// Mutate请求类
        /// </summary>
        /// <param name="token">口令</param>
        /// <param name="developToken">开发者口令</param>
        /// <param name="operations">Oprations</param>
        /// <param name="logingCustomerId">登入经理Id</param>
        /// <param name="linkedCustomerId">关联经理Id</param>
        public MutateRequest(string token, string developToken, List<Operation> operations, string logingCustomerId = null, string linkedCustomerId = null) : base(token, developToken,logingCustomerId, linkedCustomerId)
        {
            Operations = operations;
        }
        public virtual bool PartialFailure { get; set; } = false;
        public virtual bool ValidateOnly { get; set; } = false;
        public ResponseContentType responseContentType = ResponseContentType.MUTABLE_RESOURCE;
        public List<Operation> Operations { get; set; }
        public abstract string Url { get; }
    }
    /// <summary>
    /// Mutate返回类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MutateResponse<T>
    {
        public PartialFailureError partialFailureError { get; set; }
        public  List<T> results { get; set; }
    }

    public enum ResponseContentType
    {
        /// <summary>
        /// 资源名称
        /// </summary>
        UNSPECIFIED,
        /// <summary>
        /// 资源名称
        /// </summary>
        RESOURCE_NAME_ONLY,
        /// <summary>
        /// 名称和具有所有可变字段的资源
        /// </summary>
        MUTABLE_RESOURCE
    }

    public class PartialFailureError
    {
        public int code { get; set; }

        public string message { get; set; }
    }

    /// <summary>
    /// OneMutateRequest
    /// </summary>
    public abstract class OneMutateRequest : BaseRequest
    {
        /// <summary>
        /// Mutate请求类
        /// </summary>
        /// <param name="token">口令</param>
        /// <param name="developToken">开发者口令</param>
        /// <param name="operations">Oprations</param>
        /// <param name="logingCustomerId">登入经理Id</param>
        /// <param name="linkedCustomerId">关联经理Id</param>
        public OneMutateRequest(string token, string developToken, Operation operation, string logingCustomerId = null, string linkedCustomerId = null) : base(token, developToken, logingCustomerId, linkedCustomerId)
        {
            Operation = operation;
        }
        public Operation Operation { get; set; }
        public abstract string Url { get; }
    }

    /// <summary>
    /// OneMutateRequest
    /// </summary>
    public  class OneMutateResponse
    {
        public string resourceName { get; set; }

    }
}
