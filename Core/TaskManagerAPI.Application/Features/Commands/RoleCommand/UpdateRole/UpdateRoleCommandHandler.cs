using MediatR;
using TaskManagerAPI.Application.Abstractions.Services;

namespace TaskManagerAPI.Application.Features.Commands.RoleCommand.UpdateRole;
 
public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest,bool>
{
    private readonly IRoleService _roleService;

    public UpdateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<bool> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
    {

        try
        {
            var result =await _roleService.UpdateRole(request.Id, request.Name);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}