using Microsoft.EntityFrameworkCore;
using TaskManagerSolution.Domain.Entities.AuthEntities;
using TaskManagerSolution.Domain.Entities.CommonEntities;
using TaskManagerSolution.Domain.Entities.SysLog;
using TaskManagerSolution.Domain.Entities.TaskManagmentEntities;

namespace TaskManagerSolution.Application.Interfaces.IContexts;

public interface IDataBaseContext {
    DbSet<User> Users { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<Syslog> Syslogs { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<Project> Projects { get; set; }
    DbSet<ProjectTask> ProjectTasks { get; set; }
    DbSet<Priority> Priorities { get; set; }
    DbSet<UserTask> UserTasks { get; set; }
    DbSet<UserTaskCheckList> UserTaskCheckLists { get; set; }
    DbSet<TaskLog> TaskLogs { get; set; }
    DbSet<Comment> Comments { get; set; }
    int SaveChanges(bool acceptAllChangesOnSuccess);
    int SaveChanges();
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}