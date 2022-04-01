using System.Collections.Generic;
using System.Linq;

namespace Website.Shared.Extensions;

public static class Extensions
{
    public static IEnumerable<T> SafeEnumerable<T>(this IEnumerable<T>? enumerable)
    {
        return enumerable ?? Enumerable.Empty<T>();
    }
}