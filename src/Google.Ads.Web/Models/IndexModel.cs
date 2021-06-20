using Google.Ads.GoogleAds.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google.Ads.Web.Models
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// The login helper.
        /// </summary>
        public WebLoginHelper loginHelper;

        /// <summary>
        /// The Google Ads configuration.
        /// </summary>
        private GoogleAdsConfig config;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        /// <param name="configRoot">The configuration root.</param>
        public IndexModel(IConfiguration configRoot)
        {
            IConfigurationSection section = configRoot.GetSection("GoogleAdsApi");
            config = new GoogleAdsConfig(section);
        }

        /// <summary>
        /// Handles the GET call.
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet()
        {
            this.loginHelper = new WebLoginHelper(this.HttpContext, config);
            return Page();
        }

        /// <summary>
        /// Handles the POST call when the login button is clicked.
        /// </summary>
        public IActionResult OnPostLogin()
        {
            return RedirectToPage("./Login");
        }

        /// <summary>
        /// Handles the POST call when the logout button is clicked.
        /// </summary>
        public IActionResult OnPostLogout()
        {
            this.loginHelper.Logout();
            return RedirectToPage();
        }
    }
}
