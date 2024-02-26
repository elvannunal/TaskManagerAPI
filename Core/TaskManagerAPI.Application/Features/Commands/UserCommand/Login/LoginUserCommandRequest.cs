using MediatR;

namespace TaskManagerAPI.Application.Features.Commands.UserCommand.Login;

public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}