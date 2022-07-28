using TaskManagerSolution.Common.DateTool;
using TaskManagerSolution.Domain.Entities.CommonEntities;
using TaskManagerSolution.Domain.Entities.TaskManagmentEntities;

namespace TaskManagerSolution.Domain.Entities.AuthEntities;

public class User {
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string? AvatarPath { get; set; }
    public string CreatedAtDate { get; set; } = DateTime.Now.ToPersianDate();
    public string? UpdatedAtDate { get; set; }
    public bool IsActive { get; set; }
    public virtual Role Role { get; set; }
    public int RoleId { get; set; }
    public string? Token { get; set; }
    public virtual ICollection<UserTask> UserTasks { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
}