using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Commands.RoleService.UpdateRole;

public interface IUpdateRoleService {
    Task<ResponseResult> EditRoleName(int id, string name);
}