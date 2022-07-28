using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Application.Interfaces.IFasde;
using TaskManagerSolution.Application.Services.Commands.RoleService.CreateRole;
using TaskManagerSolution.Application.Services.Commands.RoleService.DeleteRole;
using TaskManagerSolution.Application.Services.Queries.RoleService.GetAllRole;

namespace TaskManagerSolution.Application.Services.Fasade;

public class RoleFasade : IRoleFasade {
    private readonly IDataBaseContext _context;

    public RoleFasade(IDataBaseContext context) {
        _context = context;
    }
    private IRoleCreateService _roleCreateService;

    public IRoleCreateService RoleCreateService {
        get {

            return _roleCreateService = _roleCreateService ?? new RoleCreateService(_context);
        }
    }
    private IRemoveRoleService _roleRemoveService;

    public IRemoveRoleService RemoveRoleService {
        get {
            return _roleRemoveService = _roleRemoveService ?? new RemoveRoleService(_context);
        }
    }
    private IGetAllRoleService _getAllRoleService;

    public IGetAllRoleService GetAllRoleService {
        get {
            return _getAllRoleService = _getAllRoleService ?? new GetAllRoleService(_context);
        }
    }
}