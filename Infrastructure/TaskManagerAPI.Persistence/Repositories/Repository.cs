using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TaskManagerAPI.Application.Repositories;
using TaskManagerAPI.Domain.Common;
using TaskManagerAPI.Persistence.Context;

namespace TaskManagerAPI.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T:BaseEntity

{
    private readonly TaskManagerDbContext _context;

    public Repository(TaskManagerDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();
    
    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.Where(method);
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(method);
    }

    public async Task<T> GetByIdAsync(Guid id, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(data => data.Id == id);
    }
    
    public async Task<bool> AddAsync(T model)
    {
        var table = _context.Set<T>();
        EntityEntry<T> entityEntry = await table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
      
    }

    public async Task<bool> AddRangeAsync(List<T> model)
    {
        await _context.Set<T>().AddRangeAsync(model);
        return true;
    }

    public bool Remove(T model)
    {
        EntityEntry<T> entityEntry = _context.Set<T>().Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }

    public bool RemoveRange(List<T> model)
    {
        _context.Set<T>().RemoveRange(model);
        return true;
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        var model=  await _context.Set<T>().FirstOrDefaultAsync(data => data.Id == id);
        return Remove(model);
    }

    public async Task<bool> UpdateAsync(T model, Guid id)
    {
        var existingEntity = await GetSingleAsync(data => data.Id == id);

        if (existingEntity != null)
        {
            _context.Entry(existingEntity).CurrentValues.SetValues(model);

            _context.Set<T>().Update(existingEntity);
       
            return true;
        }
        else
        {
            return false; 
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}