using MediatR;
using TaskManagerAPI.Application.Repositories;

namespace TaskManagerAPI.Application.Features.Commands.TeamCommand.CreateTeam;

    public class CreateTeamCommandHandler:IRequestHandler<CreateTeamCommandRequest, bool>
    {
    private readonly ITeamRepository _repository;

    public CreateTeamCommandHandler(ITeamRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(CreateTeamCommandRequest request, CancellationToken cancellationToken)
    {
            var teamGuid = Guid.NewGuid();

            var team = await _repository.AddAsync(new Domain.Entities.Team
            {
                Id = teamGuid,
                TeamId = request.TeamId,
                TeamName = request.TeamName
            });

            await _repository.SaveAsync();
            return true;
            }
    }
