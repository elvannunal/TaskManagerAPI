using MediatR;

namespace TaskManagerAPI.Application.Features.Commands.TeamCommand.DeleteTeam;

public class DeleteTeamByIdCommandRequest: IRequest<bool>
{
    public Guid Id { get; set; }
}