using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Application.Abstractions.Services.Configurations;
using TaskManagerAPI.Application.Const;
using TaskManagerAPI.Application.CustomAttributes;
using TaskManagerAPI.Application.Enums;

namespace TaskManagerAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Admin")]

public class ServicesController : ControllerBase
{
    private readonly IAuthorizeService _authorizeService;

    public ServicesController(IAuthorizeService authorizeService)
    {
        _authorizeService = authorizeService;
    }

    [HttpGet("GetAuthorize")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Authorize, ActionType = ActionType.Reading,Definition = "Reading Authorize")]

    public IActionResult GetAuthorizeDefinitionEndPoint()
    {
        var result = _authorizeService.GetAuthorizeDefinitionEndPoints(typeof(TeamController));
        return Ok(result);
    }
}