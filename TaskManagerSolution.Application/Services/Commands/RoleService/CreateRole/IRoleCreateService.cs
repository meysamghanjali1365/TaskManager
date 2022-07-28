using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Commands.RoleService.CreateRole;

public interface IRoleCreateService
{
    Task<ResponseResult> CreateRole(string Name);
}