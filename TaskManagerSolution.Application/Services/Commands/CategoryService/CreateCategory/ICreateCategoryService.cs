using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Commands.CategoryService.CreateCategory;

public interface ICreateCategoryService {
    Task<ResponseResult> CreateCategory(string name);
}