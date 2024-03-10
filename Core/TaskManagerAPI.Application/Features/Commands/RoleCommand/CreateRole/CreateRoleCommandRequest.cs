using MediatR;

namespace TaskManagerAPI.Application.Features.Commands.RoleCommand.CreateRole;

public class CreateRoleCommandRequest: IRequest<bool>
{
    public string Name { get; set; }
}