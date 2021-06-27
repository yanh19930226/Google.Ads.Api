using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Bases
{
    /// <summary>
    /// Mutate请求类
    /// </summary>
    public abstract class MutateRequest : BaseRequest
    {
        public MutateRequest(string token, string developToken, List<Operation> operations) : base(token, developToken)
        {
            Operations = operations;
        }
        public virtual bool PartialFailure { get; set; } = false;
        public List<Operation> Operations { get; set; }

        public abstract string Url { get; }
    }
}
