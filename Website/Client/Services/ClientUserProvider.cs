using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Client.Providers;
using Website.Shared.Constants;
using Website.Shared.Models;
using Website.Shared.Models.Database;

namespace Website.Client.Services
{
    public class ClientUserProvider
    {
        private readonly SteamAuthProvider steamAuth;

        public ClientUserProvider(AuthenticationStateProvider authProvider)
        {
            steamAuth = authProvider as SteamAuthProvider;
        }

        
        
        public string? SteamID => steamAuth.User?.SteamId;
        public string? Name => steamAuth.User?.Name;
        public string? DiscordName => steamAuth.User?.DiscordName;
        
        
        
        public bool IsAdmin => steamAuth.User?.Role?.Equals(Roles.Admin) ?? false;
        public bool IsAuthenticated => steamAuth.IsAuthenticated;

        public RadiumUserDTO User => steamAuth.User;
    }
}
