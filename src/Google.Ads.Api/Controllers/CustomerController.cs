using Google.Ads.Api.GoogleServices.AccountManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Google.Ads.Api.Controllers
{
    /// <summary>
    /// Customer
    /// </summary>
    [ApiController]
    [AllowAnonymous]
    [Route("Api/Customer")]
    public class CustomerController : Controller
    {
        private CreateCustomer _service{ get; set; }
        public CustomerController(CreateCustomer service)
        {
            _service = service;
        }
        [HttpGet("CreateCustomer")]
        public IActionResult CreateCustomer(long ManagerCustomerId)
        {
            return null;
        }
    }
}
