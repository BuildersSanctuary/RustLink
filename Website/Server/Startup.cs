using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;  
using System;
using System.Linq;
using AspNet.Security.OAuth.Discord;
using Website.Server.Helpers; 
using Website.Server.Services; 

namespace Website.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }
        
        
        public void ConfigureServices(IServiceCollection services)
        {
            // User Services
            services.AddDatabaseServices(Configuration);
            services.AddMapperServices();
            services.AddSingleton(new SteamWebAPI(Configuration["SteamWebAPIKey"]));           
            
            // boilerplate services
            services.AddRateLimitingServices(Configuration);
            services.AddOptions();
            services.AddSwaggerGen();
            services.AddTransient<IBaseUrl, BaseUrlService>();
            
            services.AddControllersWithViews();
            services.AddRazorPages();
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAllSchemes", policy =>
                {
                    policy.AddAuthenticationSchemes("SteamCookie");
                    policy.AddAuthenticationSchemes("DiscordCookie");
                    policy.RequireAuthenticatedUser();
                    policy.RequireAssertion(context =>
                    {
                        return context.User.Identities.Count() == 2;
                    });
                });
            });
            
            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "SteamCookie";
                })
                .AddCookie("SteamCookie", options =>
                {
                    options.LoginPath = "/signin";
                    options.LogoutPath = "/signout";
                    options.AccessDeniedPath = "/unauthorized";
                    options.ExpireTimeSpan = TimeSpan.FromDays(7);
                    options.Events.OnSignedIn = SteamAuthHelper.SignIn;
                    options.Events.OnValidatePrincipal = SteamAuthHelper.Validate;
                    options.ForwardChallenge = "Steam";
                })
                .AddSteam()
                
                
                .AddCookie("DiscordCookie", options =>
                {
                    options.LoginPath = "/signin-discord";
                    options.LogoutPath = "/signout-discord";
                    options.AccessDeniedPath = "/unauthorized";
                    options.ExpireTimeSpan = TimeSpan.FromDays(7);
                    options.Events.OnSignedIn = DiscordAuthHelper.SignIn;
                    options.Events.OnValidatePrincipal = DiscordAuthHelper.Validate;
                    options.ForwardChallenge = "Discord";

                })
                .AddDiscord(x =>
                {
                    x.CallbackPath = "/discord-callback";
                    x.SignInScheme = "DiscordCookie";

                    x.ClientId = Configuration["Discord:AppId"];
                    x.ClientSecret = Configuration["Discord:AppSecret"];
                    x.Scope.Add("guilds");
                    x.SaveTokens = true;
                })
            
                .AddCookie("GitHubCookie", options =>
                {
                    options.LoginPath = "/signin-github";
                    options.LogoutPath = "/signout-github";
                    options.AccessDeniedPath = "/unauthorized";
                    options.ExpireTimeSpan = TimeSpan.FromDays(7);
                    options.Events.OnSignedIn = GithubAuthHelper.SignIn;
                    options.Events.OnValidatePrincipal = GithubAuthHelper.Validate;
                    options.ForwardChallenge = "Github";

                })
                .AddGitHub(x =>
                {
                    x.CallbackPath = "/github-callback";
                    x.SignInScheme = "GitHubCookie";
                    x.ClientId = Configuration["Github:AppId"];
                    x.ClientSecret = Configuration["Github:AppSecret"];
                    x.SaveTokens = true;
                });
            
            

            services.AddHttpClient();
            services.AddHttpContextAccessor();
            
            services.Scan(scan => scan
                .FromAssemblyOf<Startup>()
                // Add Transient
                .AddClasses(classes => classes.AssignableTo<ITransientService>()) 
                .AsSelf()
                .WithTransientLifetime()
                // Add Singleton
                .AddClasses(classes => classes.AssignableTo<ISingletonService>()) 
                .AsSelf()
                .WithSingletonLifetime()
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseIpRateLimiting();

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            
            app.UseAuthentication();
            
            app.UseRouting();

            app.UseCookiePolicy();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }

}
