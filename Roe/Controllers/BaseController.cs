using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Roe.Controllers;

public class BaseController: ControllerBase
{
    protected string CurrentUserId => User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
}