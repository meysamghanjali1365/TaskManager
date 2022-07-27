using Microsoft.EntityFrameworkCore;
using TaskManagerSolution.Domain.Entities.AuthEntities;
using TaskManagerSolution.Domain.Entities.SysLog;

namespace TaskManagerSolution.Application.Interfaces.IContexts;

public interface IDataBaseContext {
    DbSet<User> Users { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<Syslog> Syslogs { get; set; }
    int SaveChanges(bool acceptAllChangesOnSuccess);
    int SaveChanges();
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}