using MediatR;
using TaskManagerAPI.Application.Abstractions.Services;
using TaskManagerAPI.Application.Exceptions;

namespace TaskManagerAPI.Application.Features.Commands.UserCommand.UpdatePassword;

public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommandRequest,UpdatePasswordCommandResponse>
{
    private readonly IUserService _userService;

    public UpdatePasswordCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
    {
        if (!request.Password.Equals(request.PasswordConfirm))
            throw new PasswordChangeFailedException("Girilen şifre aynı değil, lütfen şifreyi doğrulayınız!");
        
       await _userService.UpdatePasswordAsync(request.UserId, request.ResetToken, request.Password);
       return new();
    }
} 