using TaskManagerSolution.Application.Services.Commands.CategoryService.CreateCategory;

namespace TaskManagerSolution.Application.Interfaces.IFasde;

public interface ICategoryFasade
{
    ICreateCategoryService CreateCategoryService { get; }
}