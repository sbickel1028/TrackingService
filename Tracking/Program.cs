using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
#if DEV
                        .AddJsonFile($"appsettings.DEV.json", true, true)
#elif DEV2
                        .AddJsonFile($"appsettings.DEV2.json", true, true)
#elif QA
                        .AddJsonFile($"appsettings.QA.json", true, true)
#elif RELEASE
                        .AddJsonFile($"appsettings.RELEASE.json", true, true)    
#elif SBX
                        .AddJsonFile($"appsettings.SBX.json", true, true)
#elif SR
                        .AddJsonFile($"appsettings.SR.json", true, true)    
#else
                        .AddJsonFile("appsettings.json", true, true)
#endif
                            .AddEnvironmentVariables();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
