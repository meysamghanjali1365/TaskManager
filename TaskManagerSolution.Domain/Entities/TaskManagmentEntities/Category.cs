using TaskManagerSolution.Common.DateTool;

namespace TaskManagerSolution.Domain.Entities.TaskManagmentEntities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CreateAtDate { get; set; } = DateTime.Now.ToPersianDate();
    public string? UpdateAtDate { get; set; }
    public virtual ICollection<Project> Projects { get; set; }
}