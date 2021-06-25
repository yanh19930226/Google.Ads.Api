using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Google.Ads.Sdk.Models
{
    /// <summary>
    /// Mutate请求类
    /// </summary>
    public abstract class MutateRequest
    {
        public MutateRequest(List<Operation> operations)
        {
            Operations = operations;
        }

        public List<Operation> Operations { get; set; }

        public abstract string Url { get; }
    }
    /// <summary>
    /// Operation
    /// </summary>
    public class Operation { };
    /// <summary>
    /// 创建Operation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CreateOperation<T> : Operation
    {
        public CreateOperation(T createOperation)
        {
            create = createOperation;
        }
        public T create { get; set; }
    }
    /// <summary>
    /// 更新Operation
    /// </summary>
    public class UpdateOperation : Operation
    {
        public UpdateOperation(UpdateModel updateModel)
        {
            update = updateModel;

            updateMask = BuidMask(updateModel);
        }

        public string updateMask { get; set; }
        public UpdateModel update { get; set; }
        private PropertyInfo[] GetPropertyInfoArray(UpdateModel request)
        {
            PropertyInfo[] props = null;
            try
            {
                Type type = typeof(UpdateModel);
                object obj = Activator.CreateInstance(type);
                props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }
            catch (Exception ex)
            { }
            return props;
        }

        private string BuidMask(UpdateModel updateModel)
        {
            var props = GetPropertyInfoArray(updateModel);
             
            return props.Select(p => p.Name).Aggregate((x, y) => x + "," + y);
        }
    }
   
    public abstract class UpdateModel
    {
        public abstract string resourceName { get; set; }
    }
    /// <summary>
    /// 移除Operation
    /// </summary>
    public class RemoveOperation : Operation
    {
        public RemoveOperation()
        {

        }
        public string remove { get; set; }
    }
}
