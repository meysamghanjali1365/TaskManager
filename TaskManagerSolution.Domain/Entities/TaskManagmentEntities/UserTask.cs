using TaskManagerSolution.Common.DateTool;
using TaskManagerSolution.Domain.Entities.AuthEntities;

namespace TaskManagerSolution.Domain.Entities.TaskManagmentEntities;

public class UserTask
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public string CreateAtDate { get; set; } = DateTime.Now.ToPersianDate();
    public string? UpdateAtDate { get; set; }
    public virtual ProjectTask ProjectTask { get; set; }
    public int ProjectTaskId { get; set; }
    public virtual User User { get; set; }
    public int UserId { get; set; }
    public TaskStatus UserTaskStatus { get; set; } =  TaskStatus.START;
    public virtual ICollection<UserTaskCheckList> UserTaskCheckLists { get; set; }
   
}
public enum TaskStatus {
    CANSEL,
    FINISH,
    WATING,
    START,
}