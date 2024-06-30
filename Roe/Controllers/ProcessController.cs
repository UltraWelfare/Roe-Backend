using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Roe.Services.OrderStatuses;
using Roe.Services.Processes;
using Roe.Services.Processes.CreateProcess;
using Roe.Services.Processes.GetProcess;

namespace Roe.Controllers;

[ApiController]
[Route("factory/{slug}/[controller]")]
public class ProcessController(ProcessService processService): BaseController
{
    [HttpGet("")]
    [Authorize]
    public async Task<List<GetProcessItem>> GetProcesses(string slug)
    {
        return await processService.GetProcesses(CurrentUserId, slug);
    }
    
    [HttpPost("")]
    [Authorize]
    public async Task CreateProcess(string slug, [FromBody] CreateProcessParameters parameters)
    {
        await processService.CreateProcess(CurrentUserId, slug, parameters);
    }
}