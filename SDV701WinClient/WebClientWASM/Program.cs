using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorStyled;
using grpcCalls;

namespace WebClientWASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            gRPCClient.webChannelMode = true;
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddBlazorStyled();
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
