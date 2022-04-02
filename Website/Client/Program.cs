using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using MudBlazor.Services;
using Website.Client.Providers;
using Website.Client.Services;

namespace Website.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddMudServices();

            builder.Services
                .AddBlazorise(options =>
                {
                    options.Immediate = true;
                })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();
            
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore(options => 
                options.AddPolicy("RequireAllSchemes", policy =>
                {
                    policy.AddAuthenticationSchemes("SteamCookie");
                    policy.AddAuthenticationSchemes("DiscordCookie");
                    policy.RequireAuthenticatedUser();
                    policy.RequireAssertion(context =>
                    {
                        return context.User.Identities.Count() == 2;
                    });
                })
                );
            
            
            builder.Services.AddScoped<AuthenticationStateProvider, SteamAuthProvider>();
            builder.Services.AddTransient<StorageService>();
            builder.Services.AddTransient<ZIPService>();
            builder.Services.AddScoped<ClientUserProvider>(); 
            
            WebAssemblyHost host = builder.Build();
            await host.RunAsync();
        }
    }
}
