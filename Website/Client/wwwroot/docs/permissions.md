_# Permissions

Permissions in Radium work slightly differently than Oxide. Users can still have permissions attached, and can be placed into groups, but Radium uses "Policies" instead of just strings.

Policies can give access to a single string-based permission, or provide access to multiple permissions all at once. Policies can be re-used once defined, and given out to multiple users or groups to make setting up multiple related perms easier.

Mods can also ship default permissions for the main Roles Radium defines: Default, VIP, Moderator, and Admin. This is highly recommended as it will save every user from configuring permissions on every server.

Radium's permission storage backend is extensible, and you can override it with a mod or extension. For example, you could connect it to your database or API and have permissions sync automatically across your network. For performance reasons, this will always be cached locally for quick calls in hooks and with `[RequiresPermission]`.

```csharp
using System.IO.Compression;

#pragma warning disable 414, 3021

namespace MyApplication
{
    [Obsolete("...")]
    class Program : IInterface
    {
        public static List<int> JustDoIt(int count)
        {
            Span<int> numbers = stackalloc int[length];
            Console.WriteLine($"Hello {Name}!");
            return new List<int>(new int[] { 1, 2, 3 })
        }
    }
}
```

## Users

Users have two main fields:
- The list of their roles, which give them access to multiple policies all at once. If this user doesn't have any explicit permissions, they are implicitly assumed to have the default role.
- The list of their user-specific permissions, which give override access for a given user. These are not recommended as it's almost always better to make a role, and give the user this role, because Roles are easier to add/remove permissions from, because a change to the role affects all users with that role. 

You can check permissions on a user with the `HasPermission` extension API, or by passing in a `ulong userID` into the same method.

```csharp
user.HasPermission("radium.admin");
```

## Roles

Lorem ipsum

## Policies

Policies are wrapper objects for either one, or multiple permissions._