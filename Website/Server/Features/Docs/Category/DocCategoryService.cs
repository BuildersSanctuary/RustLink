using AutoMapper;
using Microsoft.Extensions.Options;
using Website.Server.Helpers;
using Website.Server.Models;
using Website.Server.Services;
using Website.Shared.Models;

namespace Website.Server.Features.Docs.Category;

public class DocCategoryService : BaseDatabaseService<DocCategory>, ISingletonService
{
    public DocCategoryService(IOptions<RadiumDatabaseSettings> dbSettings, IMapper _mapper) 
        : base("DocCategories", dbSettings, _mapper) { }
}

