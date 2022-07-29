using TaskManagerSolution.Domain.Entities.TaskManagmentEntities;

namespace TaskManagerSolution.Application.Services.Queries.CategoryService.GetAllCategory;

public class GetCategoryDto {
    public int Id { get; set; }
    public string Name { get; set; }
    public string CreateAtDate { get; set; }
    public string? UpdateAtDate { get; set; }
    public  IList<ProjectDto> Projects { get; set; }
}