using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Application.Interfaces.IFasde;
using TaskManagerSolution.Application.Services.Commands.RoleService.CreateRole;

namespace TaskManagerSolution.Application.Services.Fasade;

public class RoleFasade:IRoleFasade
{
    private readonly IDataBaseContext _context;

    public RoleFasade(IDataBaseContext context)
    {
        _context = context;
    }
    private IRoleCreateService _roleCreateService;

    public IRoleCreateService RoleCreateService
    {
        get
        {
            
            return _roleCreateService = _roleCreateService ?? new RoleCreateService(_context);
        }
    }
}