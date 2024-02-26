using MediatR;
using TaskManagerAPI.Application.Repositories;

namespace TaskManagerAPI.Application.Features.Queries.TeamQueries.GetByIdTeam;

public class GetByIdTeamQueryHandler : IRequestHandler<GetByIdTeamQueryRequest, bool>
{
    private readonly ITeamRepository _repository;

    public GetByIdTeamQueryHandler(ITeamRepository repository)
    {
        _repository = repository;
    }
    
    public Task<bool> Handle(GetByIdTeamQueryRequest request, CancellationToken cancellationToken)
    {
        var getTeamById= _repository.GetByIdAsync(request.Id,false);
        return Task.FromResult(getTeamById != null); 
    }
}