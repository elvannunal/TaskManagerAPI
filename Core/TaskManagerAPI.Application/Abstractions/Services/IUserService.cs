using TaskManagerAPI.Application.Dto;

namespace TaskManagerAPI.Application.Abstractions.Services;

public interface IUserService
{
    Task<CreateUserResponseDto> CreateAsync(CreateUserDto createUser);
    Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
}