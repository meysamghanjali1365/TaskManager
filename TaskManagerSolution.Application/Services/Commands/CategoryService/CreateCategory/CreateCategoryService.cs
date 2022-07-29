using System.Net;
using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Common.ResponseTool;
using TaskManagerSolution.Domain.Entities.TaskManagmentEntities;

namespace TaskManagerSolution.Application.Services.Commands.CategoryService.CreateCategory;

public class CreateCategoryService : ICreateCategoryService {
    private readonly IDataBaseContext _context;

    public CreateCategoryService(IDataBaseContext context) {
        _context = context;
    }
    public async Task<ResponseResult> CreateCategory(string name) {
        if (string.IsNullOrWhiteSpace(name)) {
            return new ResponseResult {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Msg = "نام دسته بندی را وارد کنید",
                IsSuccess = false
            };
        }

        try {
            var category = new Category {
                Name = name,
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return new ResponseResult {
                StatusCode = (int)HttpStatusCode.OK,
                Msg = "دسته بندی به لیست اضافه شد",
                IsSuccess = false
            };
        } catch (Exception e) {
            return new ResponseResult {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Msg = e.Message,
                IsSuccess = false
            };
        }
    }
}