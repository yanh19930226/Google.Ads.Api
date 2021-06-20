using Google.Ads.GoogleAds.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google.Ads.Web.Controllers
{
    /// <summary>
    /// The controller for the login flow.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("login")]
    public class LoginController : Controller
    {
        /// <summary>
        /// The login helper.
        /// </summary>
        private WebLoginHelper loginHelper;

        /// <summary>
        /// The Google Ads configuration.
        /// </summary>
        private GoogleAdsConfig config;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        /// <param name="configRoot">The configuration root.</param>
        public LoginController(IConfiguration configRoot)
        {
            IConfigurationSection section = configRoot.GetSection("GoogleAdsApi");
            config = new GoogleAdsConfig(section);
        }

        /// <summary>
        /// Handles the GET call.
        /// </summary>
        public IActionResult OnGet()
        {
            loginHelper = new WebLoginHelper(this.HttpContext, config);
            if (loginHelper.IsLoggedIn)
            {
                // Redirect to the main page.
                return Redirect("/Index");
            }
            else if (loginHelper.IsCallbackFromOAuthServer())
            {
                loginHelper.ExchangeAuthorizationCodeForCredentials();

                // Redirect to the main page.
                return Redirect("/Index");
            }
            else
            {
                // Redirect the user to the OAuth2 login page.
                return loginHelper.RedirectUsertoOAuthServer();
            }
        }
    }
}
