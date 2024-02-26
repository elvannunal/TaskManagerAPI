using TaskManagerAPI.Application.Repositories;
using TaskManagerAPI.Domain.Entities;
using TaskManagerAPI.Persistence.Context;

namespace TaskManagerAPI.Persistence.Repositories;

public class UserTaskRepository : Repository<UserTask>, IUserTaskRepository
{
    public UserTaskRepository(TaskManagerDbContext context) : base(context)
    {
    }
}