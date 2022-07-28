using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Commands.RoleService.DeleteRole;

public interface IRemoveRoleService
{
    Task<ResponseResult> DeleteRole(int id);
}