using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google.Ads.Api.Models.AccountManagement
{
    public class CreateCustomerDto
    {
        public CreateCustomerDto(long ManagerCustomerId)
        {
            ManagerCustomerId = ManagerCustomerId;
        }
         public long ManagerCustomerId { get; set; }
    }
}
