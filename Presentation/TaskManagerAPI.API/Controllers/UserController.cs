using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Application.Abstractions.Services;
using TaskManagerAPI.Application.Features.Commands.UserCommand.CreateUser;
using TaskManagerAPI.Application.Features.Commands.UserCommand.UpdatePassword;

namespace TaskManagerAPI.API.Controllers;
[ApiController]

public class UserController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMailService _mailService;
    
    public UserController(IMediator mediator, IMailService mailService)
    {
        _mediator = mediator;
        _mailService = mailService;
    }

    [HttpPost]
    [Route("CreateUser")]
    public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
    {
       CreateUserCommandResponse response =await _mediator.Send(createUserCommandRequest);
        return Ok(response);
    }

    [HttpPost("update-password")]
    public async Task<IActionResult> UpdatePassword(
        [FromBody] UpdatePasswordCommandRequest updatePasswordCommandRequest)
    {
        UpdatePasswordCommandResponse response = await _mediator.Send(updatePasswordCommandRequest);
        return Ok(response);
    }

}