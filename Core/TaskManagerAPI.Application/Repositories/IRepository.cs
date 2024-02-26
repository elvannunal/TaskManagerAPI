using System.Linq.Expressions;
using TaskManagerAPI.Domain.Common;

namespace TaskManagerAPI.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool tracking = true);
    
    IQueryable<T> GetWhere(Expression<Func<T, bool>> method,bool tracking = true);
    
    Task<T> GetSingleAsync(Expression<Func<T, bool>> method,bool tracking = true);
    
    Task<T> GetByIdAsync(Guid id,bool tracking = true);
    
    Task<bool> AddAsync(T model);
    
    Task<bool> AddRangeAsync(List<T> model);
    
    bool Remove(T model);
    
    bool RemoveRange(List<T> model);
    
    Task<bool> RemoveAsync(Guid id);
    
    Task<bool> UpdateAsync(T model,Guid id);
    
    Task<int> SaveAsync();
}