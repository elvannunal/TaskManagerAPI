using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Application.Features.Commands.UserCommand.Login;
using TaskManagerAPI.Application.Features.Commands.UserCommand.PasswordReset;
using TaskManagerAPI.Application.Features.Commands.UserCommand.PasswordVerify;

namespace TaskManagerAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AuthController : ControllerBase
{
    
    private readonly IMediator _mediator;
    
    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
    {
        LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
        return Ok(response);
    }

    [HttpPost("password-reset")]
    public async Task<IActionResult> PasswordReset(PasswordResetCommandRequest passwordResetCommandRequest)
    {
        var response = await _mediator.Send(passwordResetCommandRequest);
        return Ok(response);
    }

    [HttpPost("password-verify")]
    public async Task<IActionResult> PasswordVerify(PasswordVerifyCommandRequest passwordVerifyCommandRequestCommandRequest)
    {
        var response = await _mediator.Send(passwordVerifyCommandRequestCommandRequest);
        return Ok(response);
    }
}