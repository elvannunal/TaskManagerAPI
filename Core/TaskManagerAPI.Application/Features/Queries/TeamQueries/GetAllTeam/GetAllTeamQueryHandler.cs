using MediatR;
using TaskManagerAPI.Application.Repositories;
using TaskManagerAPI.Domain.Entities;

namespace TaskManagerAPI.Application.Features.Queries.TeamQueries.GetAllTeam
{
    public class GetAllTeamQueryHandler : IRequestHandler<GetAllTeamQueryRequest, List<Team>>
    {
        private readonly ITeamRepository _repository;

        public GetAllTeamQueryHandler(ITeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Team>> Handle(GetAllTeamQueryRequest request, CancellationToken cancellationToken)
        {
            var teams = _repository.GetAll().ToList();
            return teams;
        }
    }
}