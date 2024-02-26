using MediatR;

namespace TaskManagerAPI.Application.Features.Queries.TeamQueries.GetByIdTeam;

public class GetByIdTeamQueryRequest : IRequest<bool>
{
    public Guid Id { get; set; }
}