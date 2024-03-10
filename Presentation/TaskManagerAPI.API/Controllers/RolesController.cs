using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Application.Abstractions.Services;
using TaskManagerAPI.Application.Const;
using TaskManagerAPI.Application.CustomAttributes;
using TaskManagerAPI.Application.Enums;
using TaskManagerAPI.Application.Features.Commands.RoleCommand.CreateRole;
using TaskManagerAPI.Application.Features.Commands.RoleCommand.DeleteRole;
using TaskManagerAPI.Application.Features.Commands.RoleCommand.UpdateRole;
using TaskManagerAPI.Application.Features.Queries.RoleQueries.GetAllRoles;
using TaskManagerAPI.Application.Features.Queries.RoleQueries.GetRoleById;

namespace TaskManagerAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Admin")]

public class RolesController : ControllerBase
{
  private readonly IMediator _mediator;

  public RolesController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet]
  [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = ActionType.Reading,Definition = "All Roles")]
  
  public async Task<IActionResult> GetAllRoles([FromQuery]GetAllRoleQueryRequest getAllRoleQueryRequest)
  {
      GetAllRoleQueryResponse response= await _mediator.Send(getAllRoleQueryRequest);
      return Ok(response);
  }
  [HttpGet("{id}")]
  [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = ActionType.Reading,Definition = "Get Rol By Id")]

  public async Task<IActionResult> GetRoleById([FromRoute] GetRoleByIdQueryRequest getRoleByIdQueryRequest)
  {
      GetRoleByIdQueryResponse response= await _mediator.Send(getRoleByIdQueryRequest);
      return Ok(response);
  }
  
  [HttpPost("CreateRole")]
  [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = ActionType.Writing, Definition = "Create Role")]

  public async Task<IActionResult> CreateRole([FromBody]CreateRoleCommandRequest createRoleCommandRequest)
  {
      var addRole =await _mediator.Send(createRoleCommandRequest);
      return Ok(addRole);
  }
   
  [HttpPut("{id}")]
  [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = ActionType.Updating, Definition = "Update Role")]

  public async Task<IActionResult> UpdateRole([FromBody,FromRoute] UpdateRoleCommandRequest updateRoleCommandRequest)
  {
      var updateRole =await _mediator.Send(updateRoleCommandRequest);
      return Ok(updateRole);
  }
  
  [HttpDelete("{name}")]
  [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = ActionType.Deleting, Definition = "Delete Role")]

  public async Task<IActionResult> DeleteRole([FromRoute] DeleteRoleCommandRequest deleteRoleCommandRequest)
  {
      var deleteRole =await _mediator.Send(deleteRoleCommandRequest);
      return Ok(deleteRole);
  }
}