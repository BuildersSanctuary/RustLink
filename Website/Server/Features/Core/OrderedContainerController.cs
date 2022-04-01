using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Website.Server.Boilerplate.Services;
using Website.Server.Features.Core;
using Website.Server.Models;
using Website.Server.Services;
using Website.Shared.Constants;
using Website.Shared.Models.Database;

namespace Website.Server.Features.Docs.Category
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderedContainerController : BaseRadiumController<OrderedContainer, OrderedContainerDTO, OrderedContainerService>
    {
        public OrderedContainerController(OrderedContainerService dbService) : base(dbService) { }
        
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("tofront")]
        public virtual async Task<IActionResult> ToFront(string container, string name)
        {
            if (await _dbService.ChangeOrder(container, name, OrderedContainerService.OrderOption.ToFront)) 
                return NoContent();
            
            return BadRequest();
        }
        
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("toback")]
        public virtual async Task<IActionResult> ToBack(string container, string name)
        {
            if (await _dbService.ChangeOrder(container, name, OrderedContainerService.OrderOption.ToFront)) 
                return NoContent();
            
            return BadRequest();
        }
        
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("forward")]
        public virtual async Task<IActionResult> Forward(string container, string name)
        {
            if (await _dbService.ChangeOrder(container, name, OrderedContainerService.OrderOption.ToFront)) 
                return NoContent();
            
            return BadRequest();
        }
        
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("backward")]
        public virtual async Task<IActionResult> Backward(string container, string name)
        {
            if (await _dbService.ChangeOrder(container, name, OrderedContainerService.OrderOption.ToFront)) 
                return NoContent();
            
            return BadRequest();
        }
        
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("remove")]
        public virtual async Task<IActionResult> Remove(string container, string name)
        {
            if (await _dbService.ChangeOrder(container, name, OrderedContainerService.OrderOption.Remove)) 
                return NoContent();
            
            return BadRequest();
        }

        
        
        
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("insertbefore")]
        public virtual async Task<IActionResult> InsertBefore(string container, string name, string newItem)
        {
            if (await _dbService.InsertNear(container, newItem, newItem,OrderedContainerService.OrderOption.Backward)) 
                return NoContent();
            
            return BadRequest();
        }
        
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("insertafter")]
        public virtual async Task<IActionResult> InsertAfter(string container, string name, string newItem)
        {
            if (await _dbService.InsertNear(container, newItem, newItem, OrderedContainerService.OrderOption.Forward)) 
                return NoContent();
            
            return BadRequest();
        }
        
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("insertfront")]
        public virtual async Task<IActionResult> InsertAtFront(string container, string newItem)
        {
            if (await _dbService.Insert(container, newItem, OrderedContainerService.OrderOption.ToFront)) 
                return NoContent();
            
            return BadRequest();
        }
        
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("insertback")]
        public virtual async Task<IActionResult> InsertAtBack(string container, string newItem)
        {
            if (await _dbService.Insert(container, newItem, OrderedContainerService.OrderOption.ToBack)) 
                return NoContent();
            
            return BadRequest();
        } 
    }
}



