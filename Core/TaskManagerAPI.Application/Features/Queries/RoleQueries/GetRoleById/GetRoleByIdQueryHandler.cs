using System.Net;
using MediatR;
using TaskManagerAPI.Application.Abstractions.Services;
using TaskManagerAPI.Application.Features.Queries.TeamQueries.GetByIdTeam;

namespace TaskManagerAPI.Application.Features.Queries.RoleQueries.GetRoleById;

public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQueryRequest,GetRoleByIdQueryResponse>
{
    private readonly IRoleService _roleService;

    public GetRoleByIdQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<GetRoleByIdQueryResponse> Handle(GetRoleByIdQueryRequest request, CancellationToken cancellationToken)
    {
        
        var roleById = await _roleService.GetRoleById(request.Id);
        return new()
        {
            Id= roleById.id,
            Name= roleById.name
        };
        
    }
}