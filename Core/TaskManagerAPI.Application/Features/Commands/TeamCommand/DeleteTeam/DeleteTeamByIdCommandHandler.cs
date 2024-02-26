using MediatR;
using TaskManagerAPI.Application.Repositories;

namespace TaskManagerAPI.Application.Features.Commands.TeamCommand.DeleteTeam;

public class DeleteTeamByIdCommandHandler : IRequestHandler<DeleteTeamByIdCommandRequest,bool>
{
    private readonly ITeamRepository _repository;

    public DeleteTeamByIdCommandHandler(ITeamRepository repository)
    {
        _repository = repository;
    }
    public Task<bool> Handle(DeleteTeamByIdCommandRequest request, CancellationToken cancellationToken)
    {
        var deleted = _repository.RemoveAsync(request.Id);
        _repository.SaveAsync();
        return deleted;
    }
}