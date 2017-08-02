using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net.Http;

namespace RuntimeStoreDemo20
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stopWatch = Stopwatch.StartNew();
            var host = BuildWebHost(args);
            using (host)
            {
                host.Start();
                using (var client = new HttpClient())
                {
                    client.GetAsync("http://localhost:5000").GetAwaiter().GetResult();
                }
            }

            stopWatch.Stop();
            Console.WriteLine($"Took {stopWatch.ElapsedMilliseconds}ms");
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
