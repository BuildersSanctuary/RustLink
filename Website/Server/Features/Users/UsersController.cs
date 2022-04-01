using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Website.Server.Models;
using Website.Server.Services;
using Website.Shared.Constants;
using Website.Shared.Models.Database;

namespace Website.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _dbService;

        public UsersController(UsersService dbService)
        {
            _dbService = dbService;
        }
        
        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            return Ok(await _dbService.GetAllAsync<RadiumUserDTO>());
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserAsync(string userId)
        {
            return Ok(await _dbService.GetFromSteamIDAsync<RadiumUserDTO>(userId));
        }

        [Authorize] 
        [HttpGet("me")]
        public async Task<IActionResult> GetMeUserAsync()
        {
            if (!User.Identity?.IsAuthenticated ?? true) 
                return StatusCode(StatusCodes.Status401Unauthorized);
            
            return await _dbService.GetFromSteamIDAsync<RadiumUserDTO>(User.Identity?.Name) is { } user
                ? Ok(user)
                : StatusCode(StatusCodes.Status403Forbidden);
        }  
         
        
        [Authorize(AuthenticationSchemes = "DiscordCookie")]
        [Authorize(AuthenticationSchemes = "SteamCookie")]
        [HttpGet("~/dolink")]
        public async Task<IActionResult> GetDiscordIDAsync()
        {
            if (!User.Identities.Any(i => i?.AuthenticationType == "Steam"))
            {
                return Challenge(new AuthenticationProperties 
                { 
                    RedirectUri = "dolink",
                    IsPersistent = true,
                    IssuedUtc = DateTime.UtcNow,
                    ExpiresUtc = DateTime.UtcNow.AddDays(7)
                }, "Steam");
            }
            
            if (!User.Identities.Any(i => i?.AuthenticationType == "Discord"))
            {
                return Challenge(new AuthenticationProperties 
                { 
                    RedirectUri = "dolink",
                    IsPersistent = true,
                    IssuedUtc = DateTime.UtcNow,
                    ExpiresUtc = DateTime.UtcNow.AddDays(7)
                }, "Discord");
            }
            
            if (!User.Identity?.IsAuthenticated ?? true) 
                return StatusCode(StatusCodes.Status401Unauthorized);

            var Steam = User.Identities.First(i => i.AuthenticationType == "Steam");
            var Discord = User.Identities.First(i => i.AuthenticationType == "Discord");

            var SteamID = Steam.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;
            var DiscordID = Discord.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
            var DiscordName = Discord.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;
            var DiscordNumbers = Discord.Claims.FirstOrDefault(claim => claim.Type == "urn:discord:user:discriminator")?.Value;
            var DiscordFull = DiscordName + "#" + DiscordNumbers;
            
            await _dbService.LinkDiscordAndSteam(SteamID, DiscordID, DiscordFull);

            return Redirect("/link");
        }  
        
        
        
        

        [ResponseCache(NoStore = true, Duration = 0)]
        [HttpGet("~/signin"), HttpPost("~/signin")]
        public IActionResult SignIn([FromQuery] string? returnUrl = "/")
        {
            return Challenge(new AuthenticationProperties 
            { 
                RedirectUri = returnUrl,
                IsPersistent = true,
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
            }, "Steam");
        }
        
        [ResponseCache(NoStore = true, Duration = 0)]
        [HttpGet("~/signout"), HttpPost("~/signout")]
        public IActionResult LogOut([FromQuery] string? returnUrl = "/")
        {
            return SignOut(new AuthenticationProperties 
            {
                RedirectUri = returnUrl,
            }, "SteamCookie");
        }
        
        
        
        
        [ResponseCache(NoStore = true, Duration = 0)]
        [HttpGet("~/signin-discord"), HttpPost("~/signin-discord")]
        public IActionResult SignInDiscord([FromQuery] string? returnUrl = "/")
        {
            Console.WriteLine(returnUrl);
            
            return Challenge(new AuthenticationProperties 
            { 
                RedirectUri = returnUrl,
                IsPersistent = true,
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
            }, "DiscordCookie");
        }
        
        [ResponseCache(NoStore = true, Duration = 0)]
        [HttpGet("~/signout-discord"), HttpPost("~/signout-discord")]
        public IActionResult LogOutDiscord([FromQuery] string? returnUrl = "/")
        {
            return SignOut(new AuthenticationProperties 
            {
                RedirectUri = returnUrl,
            }, "DiscordCookie");
        }
        
        
        
        [ResponseCache(NoStore = true, Duration = 0)]
        [HttpGet("~/signin-github"), HttpPost("~/signin-github")]
        public IActionResult SignInGithub([FromQuery] string? returnUrl = "/")
        {
            Console.WriteLine(returnUrl);
            
            return Challenge(new AuthenticationProperties 
            { 
                RedirectUri = returnUrl,
                IsPersistent = true,
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
            }, "GitHub");
        }
        
        [ResponseCache(NoStore = true, Duration = 0)]
        [HttpGet("~/signout-github"), HttpPost("~/signout-github")]
        public IActionResult LogOutGithub([FromQuery] string? returnUrl = "/")
        {
            return SignOut(new AuthenticationProperties 
            {
                RedirectUri = returnUrl,
            }, "GitHubCookie");
        }
        
        
        
    }
}
