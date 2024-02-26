using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Application.Features.Commands.TeamCommand.CreateTeam;
using TaskManagerAPI.Application.Features.Commands.TeamCommand.DeleteTeam;
using TaskManagerAPI.Application.Features.Commands.TeamCommand.UpdateTeam;
using TaskManagerAPI.Application.Features.Queries.TeamQueries.GetAllTeam;
using TaskManagerAPI.Application.Features.Queries.TeamQueries.GetByIdTeam;
using TaskManagerAPI.Application.Repositories;

namespace TaskManagerAPI.API.Controllers;

[ApiController]
[Authorize(AuthenticationSchemes = "Admin")]

public class TeamController : ControllerBase
{ 

    private readonly ITeamRepository _repository;
    private readonly IMediator _mediator;

    public TeamController(ITeamRepository repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    [HttpGet]
    [Route("GetAllTeams")]
    public IActionResult GetAllTeams([FromQuery]GetAllTeamQueryRequest getAllTeamQueryRequest)
    {
        var teams =  _mediator.Send(getAllTeamQueryRequest);
        return Ok(teams);
    }
    
    [HttpGet("{Id}")]
    public IActionResult GetByIdTeam([FromRoute]GetByIdTeamQueryRequest getByIdTeamQueryRequest)
    {
        var result =  _mediator.Send(getByIdTeamQueryRequest);
        return Ok(result);
    }

    [HttpPost]
    [Route("AddTeam")]
    public async Task<IActionResult> AddTeamAsync(CreateTeamCommandRequest createTeamCommandRequest)
    {
        var result = await _mediator.Send(createTeamCommandRequest);

        if (result)
        {
            return StatusCode((int)HttpStatusCode.Created, "Team created successfully.");
        }

        return StatusCode((int)HttpStatusCode.InternalServerError, "Failed to create team.");
    
        
    }
    
    [HttpPut]
    [Route("UpdateTeam")]
    public async Task<IActionResult> UpdateTeamAsync([FromBody] UpdateTeamCommandRequest updateTeamCommandRequest)
    {

        var result = await _mediator.Send(updateTeamCommandRequest);

       
        if (result)
        {
            return StatusCode((int)HttpStatusCode.Created, "Team updated successfully.");
        }

        return StatusCode((int)HttpStatusCode.InternalServerError, "Failed to update team.");

    }
    
    [HttpDelete]
    [Route("RemoveIdByTeam")]
    public async Task<IActionResult> RemoveIdByTeamAsync(DeleteTeamByIdCommandRequest deleteTeamByIdCommandRequest)
    {
        var result =await _mediator.Send(deleteTeamByIdCommandRequest);
        return Ok(result);
    }
    
}