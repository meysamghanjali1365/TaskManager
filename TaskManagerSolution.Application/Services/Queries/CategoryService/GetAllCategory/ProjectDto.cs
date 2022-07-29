namespace TaskManagerSolution.Application.Services.Queries.CategoryService.GetAllCategory;

public class ProjectDto {
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? CreateAtDate { get; set; }
    public string? UpdateAtDate { get; set; }
    public bool? IsFinished { get; set; }
}