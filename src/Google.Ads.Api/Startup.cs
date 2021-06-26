using Core;
using Core.Logger;
using Core.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Google.Ads.Api
{
    public class Startup : CommonStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {

        }

        public override void CommonServices(IServiceCollection services)
        {
            #region �ͻ���

            services.Configure<Appsettings>(Configuration.GetSection("Appsettings"));
            
            #endregion

            #region  ToDo ����ע��Services

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
