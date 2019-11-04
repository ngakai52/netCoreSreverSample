using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WorkerServiceSignalR
{
    public class Program
    {
        static string url = "http://localhost:5051";//設定 SignalR Hub Server 對外的接口

        public static async Task Main(string[] args)
        {
           await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureAppConfiguration((context, config) =>
                {
                    // Configure the app here.
                })
                .ConfigureServices((hostContext, services) =>
                {
                    //services.AddHostedService<Worker>();
                })
                // Only required if the service responds to requests.
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls(url);
                    webBuilder.UseStartup<Startup>();
                });
    }
}
