using Google.Ads.GoogleAds;
using Google.Ads.GoogleAds.Config;
using Google.Ads.GoogleAds.Lib;
using Google.Ads.GoogleAds.V8.Errors;
using Google.Ads.GoogleAds.V8.Services;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google.Ads.Web.Controllers
{
    /// <summary>
    /// An API controller for making API calls and returning results as a JSON
    /// response.
    /// </summary>
    [ApiController]
    [Route("ads")]
    public class AdsController : Controller
    {
        /// <summary>
        /// The Google Ads client.
        /// </summary>
        private GoogleAdsClient client;

        /// <summary>
        /// The login helper.
        /// </summary>
        public WebLoginHelper loginHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdsController"/> class.
        /// </summary>
        /// <param name="configRoot">The configuration root.</param>
        public AdsController(IConfiguration configRoot)
        {
            IConfigurationSection section = configRoot.GetSection("GoogleAdsApi");
            GoogleAdsConfig config = new GoogleAdsConfig(section);
            client = new GoogleAdsClient(config);
        }

        /// <summary>
        /// Called before the action method is invoked.
        /// </summary>
        /// <param name="context">The action executing context.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.loginHelper = new WebLoginHelper(this.HttpContext, client.Config);
            if (loginHelper.IsLoggedIn)
            {
                client.Config.OAuth2RefreshToken = loginHelper.TokenResponse.RefreshToken;
            }
            base.OnActionExecuting(context);
        }

        /// <summary>
        /// Gets the campaigns.
        /// </summary>
        /// <param name="customerId">The customer ID.</param>
        /// <returns>The campaigns as a JSON feed.</returns>
        [HttpGet("{customerId}/campaigns")]
        public IActionResult GetCampaigns(long customerId)
        {
            // Get the GoogleAdsService.
            GoogleAdsServiceClient googleAdsService = client.GetService(
              Services.V8.GoogleAdsService);

            string query = "SELECT campaign.id, campaign.name, campaign.status FROM campaign " +
                "ORDER BY campaign.id limit 100";

            List<string> campaigns = new List<string>();
            try
            {
                // Issue a search request.
                googleAdsService.SearchStream(customerId.ToString(), query,
                    delegate (SearchGoogleAdsStreamResponse resp)
                    {
                        foreach (GoogleAdsRow googleAdsRow in resp.Results)
                        {
                            // Note: We don't use the default JSON converter, to enable
                            // better JSON rendering of enum values.
                            campaigns.Add(JsonFormatter.Default.Format(googleAdsRow.Campaign));
                        }
                    }
                );

                return Content($"[{string.Join(",\n", campaigns)}]");
            }
            catch (GoogleAdsException e)
            {
                return Problem(e.Message);
            }
        }
    }
}
