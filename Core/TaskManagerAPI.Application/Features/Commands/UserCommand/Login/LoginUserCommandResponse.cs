using TaskManagerAPI.Application.Dto;

namespace TaskManagerAPI.Application.Features.Commands.UserCommand.Login;

public class LoginUserCommandResponse
{
}

public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
{
    public Token Token { get; set; }
}

public class LoginUserErrorCommandResponse : LoginUserCommandResponse
{
    public string Message { get; set; }
}