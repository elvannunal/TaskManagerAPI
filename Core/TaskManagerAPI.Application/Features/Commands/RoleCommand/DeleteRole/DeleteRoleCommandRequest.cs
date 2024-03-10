using MediatR;

namespace TaskManagerAPI.Application.Features.Commands.RoleCommand.DeleteRole;

public class DeleteRoleCommandRequest :IRequest<bool>
{
    public string Name { get; set; }
}