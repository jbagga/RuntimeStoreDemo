using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;
using System.Net.Http;

namespace RuntimeStoreDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stopWatch = Stopwatch.StartNew();
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

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
    }
}
