using MediatR;
using TaskManagerAPI.Application.Abstractions.Services;

namespace TaskManagerAPI.Application.Features.Commands.RoleCommand.DeleteRole;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest,bool>
{
    private readonly IRoleService _roleService;

    public DeleteRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<bool> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _roleService.DeleteRole(request.Name);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}