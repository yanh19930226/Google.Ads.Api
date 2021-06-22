using Core;
using Core.Logger;
using Core.Swagger;
using Google.Ads.GoogleAds.Config;
using Google.Ads.GoogleAds.Lib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Google.Ads.Api
{
    public class Startup : CommonStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {

        }

        public override void CommonServices(IServiceCollection services)
        {
            #region 客户端

            services.Configure<Appsettings>(Configuration.GetSection("Appsettings"));

            //var settings = services.BuildServiceProvider().GetService<IOptions<Appsettings>>().Value;

            var config = new GoogleAdsConfig();
            config.DeveloperToken = "Fu8l4LAdiKG9BLBPsLB3uA";
            config.OAuth2Mode = OAuth2Flow.APPLICATION;
            config.OAuth2ClientId = "298324624669-kachgof1usnvgi9lc75f11fct1348met.apps.googleusercontent.com";
            config.OAuth2ClientSecret = "FnwDNLJt_Rqf_-CM3YjO8F6c";
            config.OAuth2RefreshToken = "1//0d95VNNbjByVjCgYIARAAGA0SNwF-L9IrP7aZsFW6uJbTiLZDRGPtnsdvMESwLSLktrQ0qsRokRlWkeD2Vkrp3z75B2XETwoA1Vw";

            //services.AddSingleton(new GoogleAdsClient(settings.GoogleAdsConfig));

            services.AddSingleton(new GoogleAdsClient(config));
            #endregion

            #region  ToDo 批量注入Services

            services.AddScoped<GoogleServices.AccountManagement.CreateCustomer>();

            #endregion

            services.AddCoreSwagger()
                        .AddCoreSeriLog();
        }

        public override void CommonConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCoreSwagger();
        }
    }
}
