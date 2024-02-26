using MediatR;
using TaskManagerAPI.Application.Abstractions.Services;

namespace TaskManagerAPI.Application.Features.Commands.UserCommand.Login;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest,LoginUserCommandResponse>
{

    private readonly IAuthService _authService;
    public LoginUserCommandHandler( IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var token = await _authService.LoginAsync(request.Email, request.Password,360);

        return new LoginUserSuccessCommandResponse()
        {
            Token = token
        };

    }
}