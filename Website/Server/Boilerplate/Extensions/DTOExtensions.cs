using AutoMapper;
using Website.Server.Models;

namespace Website.Server.Extensions;

public static class DTOExtensions
{
    public static T ToDTO<T>(this object obj, IMapper mapper)
    {
        if (obj.GetType() == typeof(T))
            return (T) obj;
        
        return mapper.Map<T>(obj);
    }
}