using MediatR;
using TaskManagerAPI.Application.Abstractions.Services;

namespace TaskManagerAPI.Application.Features.Commands.UserCommand.PasswordReset;

public class PasswordResetCommandHandler : IRequestHandler<PasswordResetCommandRequest,bool>
{
    private readonly IAuthService _authService;

    public PasswordResetCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<bool> Handle(PasswordResetCommandRequest request, CancellationToken cancellationToken)
    {
        await _authService.PasswordResetAsync(request.Email);
        return true;
    }
}