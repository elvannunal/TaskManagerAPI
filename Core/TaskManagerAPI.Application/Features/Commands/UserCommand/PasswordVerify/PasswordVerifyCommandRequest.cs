using MediatR;

namespace TaskManagerAPI.Application.Features.Commands.UserCommand.PasswordVerify;

public class PasswordVerifyCommandRequest : IRequest<bool>
{
    public string ResetToken { get; set; }
    public string UserId { get; set; }
}