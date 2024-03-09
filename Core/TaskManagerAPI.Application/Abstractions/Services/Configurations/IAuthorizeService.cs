using TaskManagerAPI.Application.Dto.Configuration;

namespace TaskManagerAPI.Application.Abstractions.Services.Configurations;

public interface IAuthorizeService
{
    List<Menu> GetAuthorizeDefinitionEndPoints(Type assemblyType);
}