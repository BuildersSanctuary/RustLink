using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Website.Server.Boilerplate.Services;
using Website.Server.Models;
using Website.Server.Services;
using Website.Shared.Constants;
using Website.Shared.Models.Database;

namespace Website.Server.Features.Docs.Category
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocCategoryController : BaseRadiumController<DocCategory, DocCategoryDTO, DocCategoryService>
    {
        public DocCategoryController(DocCategoryService dbService) : base(dbService) { }
    }
}



