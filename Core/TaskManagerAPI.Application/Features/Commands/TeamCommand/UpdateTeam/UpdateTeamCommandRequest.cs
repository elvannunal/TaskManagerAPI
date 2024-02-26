using MediatR;
using TaskManagerAPI.Domain.Entities;

namespace TaskManagerAPI.Application.Features.Commands.TeamCommand.UpdateTeam;

public class UpdateTeamCommandRequest : IRequest<bool>
{
    public Guid Id { get; set; }
    public string TeamName { get; set; }
}
