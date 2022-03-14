using Elastic.Apm.NetCoreAll;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
//using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tracking
{
    public class Startup
    {
        private static string CORS_POLICY = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy(CORS_POLICY, builder =>
            {
                builder.WithOrigins("http://localhost").AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddScoped<Applications.Interfaces.ISampleService, Applications.SampleService>();
            services.AddScoped<Tracking.Applications.Interfaces.ITrackingService, Tracking.Applications.TrackingServices>();
            services.AddScoped<Repositories.Interfaces.ISampleRepository, Repositories.SampleRepository>();
            services.AddScoped<Tracking.Repositories.Interfaces.ITrackingRepository, Tracking.Repositories.TrackingRepository>();

            services.AddScoped<Tracking.Models.TrackingServices.Abstract.IBermudaManager, Tracking.Models.TrackingServices.BermudaManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.IBlueBridgeManager, Tracking.Models.TrackingServices.BlueBridgeManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.IBuckyDropManager, Tracking.Models.TrackingServices.BuckyDropManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.ICashbashaManager, Tracking.Models.TrackingServices.CashBashaManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.IDelhiveryManager, Tracking.Models.TrackingServices.DelhiveryManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.IDHLManager, Tracking.Models.TrackingServices.DHLManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.IEgyptPostManager, Tracking.Models.TrackingServices.EgyptPostManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.IFedExManager, Tracking.Models.TrackingServices.FedExManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.IFreightmarkManager, Tracking.Models.TrackingServices.FreightmarkManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.IFreightWorksManager, Tracking.Models.TrackingServices.FreightWorkManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.IMassarManager, Tracking.Models.TrackingServices.MassarManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.INaqelManager, Tracking.Models.TrackingServices.NaqelManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.INZPostManager, Tracking.Models.TrackingServices.NZPostManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.IOmanPostManager, Tracking.Models.TrackingServices.OmanPostManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.IRedboxManger, Tracking.Models.TrackingServices.RedboxManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.ISkyCargoManager, Tracking.Models.TrackingServices.SkyCargoManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.ISkyPostalManager, Tracking.Models.TrackingServices.SkyPostalManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.ISMSAManager, Tracking.Models.TrackingServices.SMSAManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.IUPSManager, Tracking.Models.TrackingServices.UPSManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.IUSPSManager, Tracking.Models.TrackingServices.USPSManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.IXpITTrackManager, Tracking.Models.TrackingServices.XpITTrackManager>();
            services.AddScoped<Tracking.Models.TrackingServices.Abstract.IYunExpressManager, Tracking.Models.TrackingServices.YunExpressManager>();
            services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    });

            services.AddOptions();
            services.Configure<Models.ConnectionString>(Configuration.GetSection("ConnectionStrings"));

            services.AddDbContext<Tracking.Models.Tracking.TrackingContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:Tracking"]));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tracking", Version = "v1", Description = "The Microservice HTTP API. This is a Data-Driven/CRUD microservice template." });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
#if DEV || DEV2 || QA || SBX || SR
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tracking v1"));
#endif
            app.UseAllElasticApm(Configuration);

            app.UseCors(CORS_POLICY);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
