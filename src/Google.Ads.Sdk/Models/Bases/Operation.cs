using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Google.Ads.Sdk.Models.Bases
{
    /// <summary>
    /// Operation
    /// </summary>
    public abstract class Operation { };
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
    public class UpdateOperation<T> : Operation
    {
        public UpdateOperation(T updateModel)
        {
            update = updateModel;

            updateMask = BuidMask();
        }

        public string updateMask { get; set; }
        public T update { get; set; }
        private PropertyInfo[] GetPropertyInfoArray(T request)
        {
            PropertyInfo[] props = null;
            try
            {
                Type type = typeof(T);
                props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }
            catch (Exception ex)
            { }
            return props;
        }

        private string BuidMask()
        {
            var props = GetPropertyInfoArray(update);

            return props.Select(p => p.Name).Where(o => o != "resourceName").Aggregate((x, y) => x + "," + y);
        }
    }
    /// <summary>
    /// 移除Operation
    /// </summary>
    public class RemoveOperation : Operation
    {
        public string remove { get; set; }
    }
}
