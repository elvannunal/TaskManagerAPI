using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskManagerAPI.Application.Abstractions.Services;
using TaskManagerAPI.Application.Dto;
using TaskManagerAPI.Domain.Entities;

namespace TaskManagerAPI.Application.Features.Commands.UserCommand.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
{

    private readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService user)
    {
        _userService = user;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        CreateUserResponseDto response = await _userService.CreateAsync(new()
        {
            Email = request.Email, 
            NameSurname = request.NameSurname,
            UserName = request.UserName,
            Password = request.Password
        });

        return new()
        {
            Message = response.Message,
            Succeeded = response.Succeeded
        };



    }
}