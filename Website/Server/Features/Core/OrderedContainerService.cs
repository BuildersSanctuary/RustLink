using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Website.Server.Extensions;
using Website.Server.Features.Core;
using Website.Server.Helpers;
using Website.Server.Models;
using Website.Server.Services;
using Website.Shared.Models;

namespace Website.Server.Features.Docs.Category;

public class OrderedContainerService : BaseDatabaseService<OrderedContainer>, ISingletonService
{
    public OrderedContainerService(IOptions<RadiumDatabaseSettings> dbSettings, IMapper _mapper) 
        : base("Containers", dbSettings, _mapper) { }


    public enum OrderOption
    {
        ToFront,
        ToBack,
        Forward,
        Backward,
        Remove
    }
    
    public virtual async Task<bool> ChangeOrder(string containerName, string itemName, OrderOption option)
    {
        OrderedContainer container = await GetByNameAsync(containerName);
        int index = container.Items.FindIndex(i => i == itemName);
        if (index == -1)
            return false;
        
        string item = container.Items[index];
        container.Items.RemoveAt(index);
            
        switch (option)
        {
            case OrderOption.ToFront:
                container.Items.Insert(0, item);
                break;
            case OrderOption.ToBack:
                container.Items.Add(item);
                break;
            case OrderOption.Forward:
                container.Items.Insert(Math.Min(container.Items.Count, index + 1), item);
                break;
            case OrderOption.Backward:
                container.Items.Insert(Math.Max(0, index - 1), item);
                break;
        }

        await UpdateAsync(container);
        
        return true;
    }
    
    public virtual async Task<bool> Insert(string containerName, string newItem, OrderOption option)
    {
        OrderedContainer container = await GetByNameAsync(containerName); 
         
        switch (option)
        {
            case OrderOption.ToFront:
                container.Items.Insert(0, newItem);
                break;
            case OrderOption.ToBack:
                container.Items.Add(newItem);
                break; 
        }

        await UpdateAsync(container);
        
        return true;
    }
    
    public virtual async Task<bool> InsertNear(string containerName, string itemName, string newItem, OrderOption option)
    {
        OrderedContainer container = await GetByNameAsync(containerName); 
         
        int index = container.Items.FindIndex(i => i == itemName);
        if (index == -1)
            return false;
        
        switch (option)
        {
            case OrderOption.Forward:
                container.Items.Insert(index + 1, newItem);
                break;
            case OrderOption.Backward:
                container.Items.Insert(index, newItem);
                break; 
        }

        await UpdateAsync(container);
        
        return true;
    }
}

