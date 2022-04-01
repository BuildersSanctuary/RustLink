using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging; 
using System;
using System.Collections.Generic; 
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks; 
using Website.Server.Models;
using Website.Server.Services;
using Website.Shared.Constants; 

namespace Website.Server.Helpers
{
    public class SteamAuthHelper
    {
        private const int SteamIdStartIndex = 37;

        public static async Task SignIn(CookieSignedInContext context)
        {            

            if (context == null) throw new ArgumentNullException(nameof(context));
            
            var usersRepository = context.HttpContext.RequestServices.GetRequiredService<UsersService>();
            string steamId = context.Principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value[SteamIdStartIndex..];
            Console.WriteLine(steamId);

            if (steamId == null)
                throw new NullReferenceException();

            
            RadiumUser user = await usersRepository.GetFromSteamIDAsync<RadiumUser>(steamId);
            if (user != null)
                return;
            
            var steamFactory = context.HttpContext.RequestServices.GetRequiredService<SteamWebAPI>();
            var httpClientFactory = context.HttpContext.RequestServices.GetRequiredService<IHttpClientFactory>();
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<SteamAuthHelper>>();

            var client = httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(3);

            PlayerSummaryModel playerSummary = null;

            try
            {
                playerSummary = await steamFactory.GetSummary(steamId); 
            }
            catch (Exception e)
            {
                logger.LogError(e, "An exception occurated when downloading player summaries");
            }

            user = new RadiumUser()
            {
                SteamId = steamId,
                Role = Roles.User,
                CreateDate = DateTime.Now
            };

            if (playerSummary != null)
            {
                user.Name = playerSummary.Nickname;
                user.AvatarImageURL = playerSummary.Avatar;
            }

            await usersRepository.CreateAsync(user);
        }

        public static async Task Validate(CookieValidatePrincipalContext context)
        {
            string steamId = context.Principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value[SteamIdStartIndex..];
            if (steamId == null)
                throw new NullReferenceException();
            
            UsersService usersRepository = context.HttpContext.RequestServices.GetRequiredService<UsersService>();
            RadiumUser? user = await usersRepository.GetFromSteamIDAsync<RadiumUser>(steamId);
            
            if (user == null)
                return;
            
            List<Claim> claims = new List<Claim>
            {
                new (ClaimTypes.Name, user.SteamId),
                new (ClaimTypes.Role, user.Role)
            };

            context.ReplacePrincipal(new ClaimsPrincipal(new ClaimsIdentity(claims, "Steam")));
        }
    }
}
