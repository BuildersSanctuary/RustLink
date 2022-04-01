using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Website.Server.Models;
using Website.Server.Services;
using Website.Shared.Constants;
using Website.Shared.Models.Database;

namespace Website.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocsController : ControllerBase
    {
        private readonly DocsService _dbService;

        public DocsController(DocsService dbService)
        {
            _dbService = dbService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetDocsAsync()
        {
            return Ok(await _dbService.GetAllAsync<DocDTO>());
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetDocAsync(string name)
        {
            return Ok(await _dbService.GetByNameAsync<DocDTO>(name));
        } 
        
        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        public async Task<IActionResult> Update(DocDTO updatedBook)
        {
            await _dbService.UpdateAsync(updatedBook);
            return NoContent();
        }
    }
}
