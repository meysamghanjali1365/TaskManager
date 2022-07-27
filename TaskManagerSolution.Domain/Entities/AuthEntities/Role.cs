using TaskManagerSolution.Common.DateTool;

namespace TaskManagerSolution.Domain.Entities.AuthEntities;

public class Role
{
    public int Id { get; set; }
    public string RoleName { get; set; }
    public string CreatedAtDate { get; set; }= DateTime.Now.ToPersianDate();
    public string? UpdatedAtDate { get; set; }
    public virtual ICollection<User> Users { get; set; }    
}