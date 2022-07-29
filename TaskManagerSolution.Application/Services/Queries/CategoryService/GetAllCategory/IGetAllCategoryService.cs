using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Queries.CategoryService.GetAllCategory;

public interface IGetAllCategoryService
{
    Task<ResponseResult<List<GetCategoryDto>>> GetCategories(string? key);
}