using MediatR;

namespace TaskManagerAPI.Application.Features.Commands.TeamCommand.CreateTeam;

public class CreateTeamCommandRequest : IRequest<bool>
{
    public int TeamId { get; set; }
    public string TeamName { get; set; }
}


