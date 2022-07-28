using TaskManagerSolution.Common.DateTool;

namespace TaskManagerSolution.Domain.Entities.TaskManagmentEntities;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CreateAtDate { get; set; } = DateTime.Now.ToPersianDate();
    public string? UpdateAtDate { get; set; }
    public virtual Category Category { get; set; }
    public int CategoryId { get; set; }
    public bool IsFinished { get; set; } = false;
    public virtual ICollection<ProjectTask> ProjectTasks { get; set; }

}