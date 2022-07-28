using TaskManagerSolution.Application.Services.Commands.RoleService.CreateRole;
using TaskManagerSolution.Application.Services.Commands.RoleService.DeleteRole;
using TaskManagerSolution.Application.Services.Commands.RoleService.UpdateRole;
using TaskManagerSolution.Application.Services.Queries.RoleService.GetAllRole;

namespace TaskManagerSolution.Application.Interfaces.IFasde;

public interface IRoleFasade
{
    IRoleCreateService RoleCreateService { get; }
    IRemoveRoleService RemoveRoleService { get; }
    IGetAllRoleService GetAllRoleService { get; }
    IUpdateRoleService UpdateRoleService { get; }
}