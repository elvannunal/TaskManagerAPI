using MediatR;

namespace TaskManagerAPI.Application.Features.Queries.RoleQueries.GetRoleById;

public class GetRoleByIdQueryRequest : IRequest<GetRoleByIdQueryResponse>
{
    public string Id { get; set; }

}