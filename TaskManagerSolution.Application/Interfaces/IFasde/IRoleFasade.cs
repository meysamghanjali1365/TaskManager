using TaskManagerSolution.Application.Services.Commands.RoleService.CreateRole;

namespace TaskManagerSolution.Application.Interfaces.IFasde;

public interface IRoleFasade
{
    IRoleCreateService RoleCreateService { get; }
}