using MediatR;
using TaskManagerAPI.Application.Abstractions.Services;

namespace TaskManagerAPI.Application.Features.Commands.RoleCommand.CreateRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest , bool>
{
    private readonly IRoleService _roleService;

    public CreateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<bool> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await _roleService.CreateRole(request.Name);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
       
    }
}