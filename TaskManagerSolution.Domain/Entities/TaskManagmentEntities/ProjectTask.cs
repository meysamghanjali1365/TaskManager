using TaskManagerSolution.Common.DateTool;

namespace TaskManagerSolution.Domain.Entities.TaskManagmentEntities;

public class ProjectTask
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsFinished { get; set; } = false;
    public string CreateAtDate { get; set; } = DateTime.Now.ToPersianDate();
    public string? UpdateAtDate { get; set; }
    public string? FinishedAtDate { get; set; }
    public virtual Project Project { get; set; }
    public int ProjectId { get; set; }
    public virtual Priority Priority { get; set; }
    public int PriorityId { get; set; }
}