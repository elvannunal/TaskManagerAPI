using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using TaskManagerAPI.Application.Abstractions.Services;
using TaskManagerAPI.Application.Dto;
using TaskManagerAPI.Application.Exceptions;
using TaskManagerAPI.Application.Helpers;
using TaskManagerAPI.Domain.Entities;

namespace TaskManagerAPI.Persistence.Services;

public class UserService : IUserService
{
    private UserManager<User> _user;

    public UserService(UserManager<User> user)
    {
        _user = user;
    }

    public async Task<CreateUserResponseDto> CreateAsync(CreateUserDto createUser)
    {
        IdentityResult result = await _user.CreateAsync(new()
        {
            Id=Guid.NewGuid().ToString(),
            NameSurname = createUser.NameSurname,
            UserName = createUser.UserName,
            Email = createUser.Email
        }, createUser.Password);

        CreateUserResponseDto response = new() { Succeeded = result.Succeeded };
        
        if (result.Succeeded)
        {
            response.Message = "Kullanıcı başarıyla eklenmiştir.";
        }
        else
        {
            foreach (var error in result.Errors)
            {
                response.Message += $"{error.Code}-{error.Description}";
            }
        }

        return response;
    }

    public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
    {
      User user = await _user.FindByIdAsync(userId);
      
      if (user != null)
      {
          resetToken = resetToken.UrlDecode();
          IdentityResult result =await _user.ResetPasswordAsync(user, resetToken, newPassword);
          if (result.Succeeded)
              await _user.UpdateSecurityStampAsync(user);
          else
              throw new PasswordChangeFailedException();

      }
    }
}