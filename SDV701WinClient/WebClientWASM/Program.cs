/*
 * Author: Oleg Sivers
 * Date: 06.06.2020
 * Desc: Auto-generated
*/

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BlazorStyled;
using grpcCalls;
using Blazored.LocalStorage;

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
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            await builder.Build().RunAsync();
        }
    }
}
