using MediatR;
using TaskManagerAPI.Domain.Entities;

namespace TaskManagerAPI.Application.Features.Queries.TeamQueries.GetAllTeam;

public class GetAllTeamQueryRequest :  IRequest<List<Team>>
{
    
}