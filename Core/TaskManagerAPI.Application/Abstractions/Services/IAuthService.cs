using TaskManagerAPI.Application.Features.Commands.UserCommand.Login;

namespace TaskManagerAPI.Application.Abstractions.Services;

public interface IAuthService
{
     Task<Dto.Token> LoginAsync(string email, string password, int accessTokenLifeTime);

     Task PasswordResetAsync(string email);

     Task<bool> PasswordVerify(string resetToken, string userId);
}