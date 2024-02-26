using MediatR;
using TaskManagerAPI.Application.Abstractions.Services;
using TaskManagerAPI.Application.Features.Commands.UserCommand.PasswordReset;

namespace TaskManagerAPI.Application.Features.Commands.UserCommand.PasswordVerify;

public class PasswordVerifyCommandHandler : IRequestHandler<PasswordVerifyCommandRequest,bool>
{
    private readonly IAuthService _authService;

    public PasswordVerifyCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<bool> Handle(PasswordVerifyCommandRequest request, CancellationToken cancellationToken)
    {
       bool state = await _authService.PasswordVerify(request.ResetToken, request.UserId);
       return state;
    }
}