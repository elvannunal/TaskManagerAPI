using MediatR;

namespace TaskManagerAPI.Application.Features.Commands.RoleCommand.UpdateRole;

public class UpdateRoleCommandRequest : IRequest<bool>
{
    public string Id { get; set; }
    public string Name { get; set; }
    
}