using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MicroService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var config = new ConfigurationBuilder().AddCommandLine(args).Build();
            var ip = config["ip"];
            var port = config["port"];

            return WebHost.CreateDefaultBuilder(args)
                    //.ConfigureAppConfiguration((host, configuration) =>
                    //{
                    //    configuration.AddCommandLine(args);
                    //})
                    .UseStartup<Startup>().UseUrls($"http://{ip}:{port}")
                    .Build();
        }

    }
}
