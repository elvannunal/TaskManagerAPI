using TaskManagerAPI.Application.Repositories;
using TaskManagerAPI.Domain.Entities;
using TaskManagerAPI.Persistence.Context;

namespace TaskManagerAPI.Persistence.Repositories;

public class TeamRepository : Repository<Team> , ITeamRepository
{
    public TeamRepository(TaskManagerDbContext context) : base(context)
    {
    }
}