using MediatR;
using TaskManagerAPI.Application.Abstractions.Services;
using TaskManagerAPI.Application.Features.Queries.TeamQueries.GetByIdTeam;

namespace TaskManagerAPI.Application.Features.Queries.RoleQueries.GetAllRoles;

public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQueryRequest,GetAllRoleQueryResponse>
{
    private readonly IRoleService _roleService;

    public GetAllRoleQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<GetAllRoleQueryResponse> Handle(GetAllRoleQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var roles =  _roleService.GetAllRoles();
            return new()
            {
                Datas = roles
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("Roles Not Found!");
        }
    }
}