namespace TaskManagerSolution.Domain.Entities.TaskManagmentEntities;

public class Priority
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<ProjectTask> ProjectTasks { get; set; }
}