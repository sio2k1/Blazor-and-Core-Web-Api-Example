/*
 * Author: Automatically generated
 * Date: 01.06.2020
*/
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SDV701BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
