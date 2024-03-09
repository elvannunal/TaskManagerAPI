using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Application.Abstractions.Services.Configurations;

namespace TaskManagerAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicesController : ControllerBase
{
    private readonly IAuthorizeService _authorizeService;

    public ServicesController(IAuthorizeService authorizeService)
    {
        _authorizeService = authorizeService;
    }

    [HttpGet("GetAuthorize")]
    public IActionResult GetAuthorizeDefinitionEndPoint()
    {
        var result = _authorizeService.GetAuthorizeDefinitionEndPoints(typeof(TeamController));
        return Ok(result);
    }
}