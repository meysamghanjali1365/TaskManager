using System.Net;
using Microsoft.EntityFrameworkCore;
using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Commands.RoleService.DeleteRole;

public class RemoveRoleService : IRemoveRoleService {
    private readonly IDataBaseContext _context;

    public RemoveRoleService(IDataBaseContext context) {
        _context = context;
    }

    public async Task<ResponseResult> DeleteRole(int id) {
        var userWhitRole = await _context.Users.Where(u => u.RoleId == id).ToListAsync();
        var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
        if (userWhitRole.Count > 0) {
            return new ResponseResult {
                Msg = "امکان حذف نیست زیرا کاربرانی در سیستم با این نقش وجود دارند",
                StatusCode = (int)HttpStatusCode.BadRequest,
                IsSuccess = false
            };
        }
        if (role == null) {
            return new ResponseResult {
                Msg = "نقش یافت نشد",
                StatusCode = (int)HttpStatusCode.NotFound,
                IsSuccess = false
            };
        }
        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
        return new ResponseResult {
            Msg = "نقش با موفقیت حذف شد",
            StatusCode = (int)HttpStatusCode.NotFound,
            IsSuccess = true
        };
    }
}