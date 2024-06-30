using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Roe.Services.Factories;
using Microsoft.AspNetCore.Identity;
using Roe.Entities;
using Roe.Services.Factories.CreateFactory;
using Roe.Services.Factories.GetFactory;

namespace Roe.Controllers;


[ApiController]
[Route("[controller]")]
public class FactoryController(FactoryService factoryService): BaseController
{
    
    [HttpGet("{slug}")]
    [Authorize]
    public async Task<Factory> Get(string slug)
    {
        var result = await factoryService.GetFactoryBySlug(CurrentUserId, slug);
        return result;
    }
    
    [HttpPost("create")]
    [Authorize]
    public async Task<CreateFactoryResponse> Create([FromBody] CreateFactoryParameters parameters)
    {
        var result = await factoryService.CreateFactory(CurrentUserId, parameters);
        return result;
    }
    
    [HttpGet("")]
    [Authorize]
    public async Task<List<GetFactoryItem>> Get()
    {
        var result = await factoryService.GetFactories(CurrentUserId);
        return result;
    }
}