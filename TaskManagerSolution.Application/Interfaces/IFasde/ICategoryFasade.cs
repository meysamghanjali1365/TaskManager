using TaskManagerSolution.Application.Services.Commands.CategoryService.CreateCategory;
using TaskManagerSolution.Application.Services.Queries.CategoryService.GetAllCategory;

namespace TaskManagerSolution.Application.Interfaces.IFasde;

public interface ICategoryFasade
{
    ICreateCategoryService CreateCategoryService { get; }
    IGetAllCategoryService GetAllCategoryService { get; }
}