namespace TaskManagerAPI.Application.Abstractions.Token;

public interface ITokenHandler
{
    Dto.Token CreateAccessToken(int date);
}