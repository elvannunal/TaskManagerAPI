using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Domain.Common;
using TaskManagerAPI.Domain.Entities;

namespace TaskManagerAPI.Persistence.Context;

public class TaskManagerDbContext : IdentityDbContext<User, UserRole,string>
{
    public TaskManagerDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Team> Teams { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserTask> UserTasks { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>()
            .HasOne(t => t.TeamLead)
            .WithMany(u => u.Teams)
            .HasForeignKey(t => t.TeamLeadId);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken =default)
    {
        var datas = ChangeTracker.Entries<BaseEntity>();

        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow
            };
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}

