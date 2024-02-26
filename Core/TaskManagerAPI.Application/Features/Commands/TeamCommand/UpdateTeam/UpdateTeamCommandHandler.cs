using MediatR;
using TaskManagerAPI.Application.Repositories;

namespace TaskManagerAPI.Application.Features.Commands.TeamCommand.UpdateTeam;

public class UpdateTeamCommandHandler: IRequestHandler<UpdateTeamCommandRequest, bool>
{
    private readonly ITeamRepository _repository;

    public UpdateTeamCommandHandler(ITeamRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<bool> Handle(UpdateTeamCommandRequest request, CancellationToken cancellationToken)
    {
        var existingTeam = await _repository.GetByIdAsync(request.Id);

        if (existingTeam != null)
        {
            existingTeam.TeamName = request.TeamName;
        }

        await _repository.UpdateAsync(existingTeam, request.Id);

        return await _repository.SaveAsync() > 0;
    }
}
