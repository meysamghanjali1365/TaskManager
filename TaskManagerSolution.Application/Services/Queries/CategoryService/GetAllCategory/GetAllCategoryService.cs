using System.Net;
using Microsoft.EntityFrameworkCore;
using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Queries.CategoryService.GetAllCategory;

public class GetAllCategoryService : IGetAllCategoryService {
    private readonly IDataBaseContext _context;

    public GetAllCategoryService(IDataBaseContext context) {
        _context = context;
    }

    public async Task<ResponseResult<List<GetCategoryDto>>> GetCategories(string? key) {
        var users = _context.Categories
            .AsQueryable();
        if (!string.IsNullOrWhiteSpace(key)) {
            users = users.Where(u => u.Name.Contains(key)).AsQueryable();
        }
        var listUser = await users.Select(u => new GetCategoryDto() {
           Name = u.Name,
           CreateAtDate = u.CreateAtDate,
           Id = u.Id,
           UpdateAtDate = u.UpdateAtDate,
           Projects = u.Projects.Select(p => new ProjectDto
           {
               Id = p.Id,
               UpdateAtDate = p.UpdateAtDate,
               CreateAtDate = p.CreateAtDate,
               IsFinished = p.IsFinished,
               Name = p.Name
           }).ToList(),
        }).ToListAsync();
        return new ResponseResult<List<GetCategoryDto>>() {
            Result = listUser,
            IsSuccess = true,
            StatusCode = (int)HttpStatusCode.OK,
            Msg = ""
        };
    }
}