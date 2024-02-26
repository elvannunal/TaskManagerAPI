using MediatR;

namespace TaskManagerAPI.Application.Features.Commands.UserCommand.PasswordReset;

public class PasswordResetCommandRequest : IRequest<bool>
{
    public string Email { get; set; }
}