using TaskManagerSolution.Common.DateTool;

namespace TaskManagerSolution.Domain.Entities.TaskManagmentEntities;

public class UserTaskCheckList {
    public int Id { get; set; }
    public string CheckListName { get; set; }
    public bool IsFinished { get; set; } = false;
    public string CreateAtDate { get; set; } = DateTime.Now.ToPersianDate();
    public string? UpdateAtDate { get; set; }
    public string? FinishedAtDate { get; set; }
    public virtual UserTask UserTask { get; set; }
    public int UserTaskId { get; set; }
}