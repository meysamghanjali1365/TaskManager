using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Common.RoleSeed;
using TaskManagerSolution.Common.Setting;
using TaskManagerSolution.Domain.Entities.AuthEntities;
using TaskManagerSolution.Domain.Entities.SysLog;

namespace TaskManagerSolution.Persistence.Contexts;

public class DataBaseContext : DbContext, IDataBaseContext {
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Syslog> Syslogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        SeedData(modelBuilder);
        modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
        modelBuilder.Entity<User>().HasIndex(u => u.Phone).IsUnique();
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys())) {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
        base.OnModelCreating(modelBuilder);
    }
    private void SeedData(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Role>().HasData(new Role { Id = 1, RoleName = nameof(UserRoles.Admin) });
        modelBuilder.Entity<Role>().HasData(new Role { Id = 2, RoleName = nameof(UserRoles.Customer) });
    }
}