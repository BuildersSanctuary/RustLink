using Microsoft.AspNetCore.Authorization;

namespace Website.Server.Features.Auth;

public class PermissionRequirement : IAuthorizationRequirement
{
    public string Permission { get; private set; }
    
    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }
} 