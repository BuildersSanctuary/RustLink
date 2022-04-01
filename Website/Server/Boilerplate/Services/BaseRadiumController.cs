using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Website.Server.Models;
using Website.Server.Services;
using Website.Shared.Constants;
using Website.Shared.Models;

namespace Website.Server.Boilerplate.Services;

public abstract class BaseRadiumController<TData, TDTO, TDBService> : ControllerBase
    where TDBService : BaseDatabaseService<TData>
    where TData : IDatabaseObject
    where TDTO : IDTO
{
    protected readonly TDBService _dbService;

    public BaseRadiumController(TDBService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet]
    public virtual async Task<IActionResult> GetDocsAsync()
    {
        return Ok(await _dbService.GetAllAsync<TDTO>());
    }

    [HttpGet("{name}")]
    public virtual async Task<IActionResult> GetDocAsync(string name)
    {
        return Ok(await _dbService.GetByNameAsync<TDTO>(name));
    } 
        
    [Authorize(Roles = Roles.Admin)]
    [HttpPut]
    public virtual async Task<IActionResult> Update(TDTO updated)
    {
        await _dbService.UpdateAsync(updated);
        return NoContent();
    }
    
    [Authorize(Roles = Roles.Admin)]
    [HttpDelete("{name}")]
    public virtual async Task<IActionResult> Delete(string name)
    {
        await _dbService.RemoveByNameAsync(name);
        return NoContent();
    }
}