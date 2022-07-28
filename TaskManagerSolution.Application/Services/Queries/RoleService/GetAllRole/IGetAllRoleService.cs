using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Queries.RoleService.GetAllRole;

public interface IGetAllRoleService
{
    Task<ResponseResult<List<GetAllRoleDto>>> GetAllRole(string? searchKey);
}