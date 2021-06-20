using Core;
using Core.Logger;
using Core.Swagger;
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

            services.AddSingleton(new GoogleAdsClient(/*settings.GoogleAdsConfig*/));
            #endregion

            #region  ToDo 批量注入Services
            services.AddScoped<GoogleServices.AccountManagement.CreateCustomer>();
            //services.AddScoped<IBusinessManagerService, BusinessManagerService>();
            //services.AddScoped<IBusinessAssetService, BusinessAssetService>();
            //services.AddScoped<ISystemUserService, SystemUserService>();//IBusinessManagerService
            //services.AddScoped<IBusinessManagerService, BusinessManagerService>();
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
