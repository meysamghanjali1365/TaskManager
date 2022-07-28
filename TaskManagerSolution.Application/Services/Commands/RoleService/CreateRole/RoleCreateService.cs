using System.Net;
using Microsoft.EntityFrameworkCore;
using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Common.ResponseTool;
using TaskManagerSolution.Domain.Entities.AuthEntities;

namespace TaskManagerSolution.Application.Services.Commands.RoleService.CreateRole;

public class RoleCreateService : IRoleCreateService
{
    private readonly IDataBaseContext _context;

    public RoleCreateService(IDataBaseContext context)
    {
        _context = context;
    }

    public async Task<ResponseResult> CreateRole(string Name)
    {
        var roleFind = await _context.Roles.FirstOrDefaultAsync(u => u.RoleName.Equals(Name));
        if (roleFind !=null)
        {
            return new ResponseResult()
            {
                StatusCode = (int) HttpStatusCode.BadRequest,
                Msg = "ین نقش در سیستم وجود دارد",
                IsSuccess = false
            };
        }

        Role role = new Role
        {
            RoleName = Name
        };
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
        return new ResponseResult() {
            StatusCode = (int)HttpStatusCode.OK,
            Msg = "نقش در سیستم اضافه شد",
            IsSuccess = true
        };
    }
}