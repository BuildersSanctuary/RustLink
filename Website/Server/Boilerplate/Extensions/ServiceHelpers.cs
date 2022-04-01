using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AngleSharp;
using AspNetCoreRateLimit;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Website.Server.Helpers;
using Website.Server.Models;
using Website.Server.Services;
using Website.Shared.Models;
using Website.Shared.Models.Database;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Website.Server;

public static class ServiceHelpers
{
    
    public static void AddDatabaseServices(this IServiceCollection services, IConfiguration Configuration)
    {
        services.Configure<RadiumDatabaseSettings>(Configuration.GetSection("RadiumDatabase"));
        services.AddSingleton<UsersService>();
        services.AddSingleton<DocsService>();
    }

    public static IMappingExpression<TDestination, TSource> ObjectToDTO<TSource, TDestination>(IMapperConfigurationExpression cfg)
        where TSource : IDatabaseObject
        where TDestination : IDTO
    {
         cfg.CreateMap<TSource, TDestination>(); 
         return cfg.CreateMap<TDestination, TSource>()
                    .ForMember("Id", Member => Member.Ignore());   
    }
        
    public static void AddMapperServices(this IServiceCollection services)
    {
        var configuration = new MapperConfiguration(cfg => 
        {
            IEnumerable<Type> types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsDefined(typeof(AutoDTOAttribute)));
            var assembly = Assembly.GetExecutingAssembly();

            foreach (var type in assembly.GetTypes())
            {
                if (!typeof(IDatabaseObject).IsAssignableFrom(type))
                    continue;
                
                var dtoAttribute = type.GetCustomAttribute<AutoDTOAttribute>();
                if (dtoAttribute != null)
                {
                    if (!typeof(IDTO).IsAssignableFrom(dtoAttribute.DTO))
                        continue;
                    
                    cfg.CreateMap(type, dtoAttribute.DTO); 
                    cfg.CreateMap(dtoAttribute.DTO, type)
                        .ForMember("Id", Member => Member.Ignore());                  
                }
            }
            
            //ObjectToDTO<DocCategory, DocCategoryDTO>();
        });
            
        #if DEBUG
        configuration.AssertConfigurationIsValid();
        #endif
        
        services.AddSingleton(configuration.CreateMapper());
    }
    
    public static void AddRateLimitingServices(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddMemoryCache();
        services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimit"));
        services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
        services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
    }
    
    
}