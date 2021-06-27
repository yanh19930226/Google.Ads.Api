using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Ads.Sdk.Models.Bases
{
    public class MutateOperationsBuilder
    {
        public List<Operation> Operations;
        public MutateOperationsBuilder()
        {
            Operations = new List<Operation>();
        }
        public List<Operation> Build()
        {
            return Operations;
        }
    }

    public static class MutateOperationsBuilderExtesions
    {
        public static MutateOperationsBuilder ConfigureCreateOperation<T>(
           this MutateOperationsBuilder builder,
            CreateOperation<T> createOperation)
        {

            builder.Operations.Add(createOperation);
            return builder;
        }
        public static MutateOperationsBuilder ConfigureUpdateCreateOperation<T>(
          this MutateOperationsBuilder builder,
           UpdateOperation<T> updateOperation)
        {

            builder.Operations.Add(updateOperation);
            return builder;
        }

        public static MutateOperationsBuilder ConfigureRemoveOperation(
          this MutateOperationsBuilder builder,
           RemoveOperation removeOperation)
        {
            builder.Operations.Add(removeOperation);
            return builder;
        }
    }
}
