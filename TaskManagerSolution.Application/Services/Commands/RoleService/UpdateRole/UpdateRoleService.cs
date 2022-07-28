using System.Net;
using Microsoft.EntityFrameworkCore;
using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Common.DateTool;
using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Commands.RoleService.UpdateRole;

public class UpdateRoleService : IUpdateRoleService {
    private readonly IDataBaseContext _context;

    public UpdateRoleService(IDataBaseContext context) {
        _context = context;
    }

    public async Task<ResponseResult> EditRoleName(int id, string name) {
        var userWhitRole = await _context.Users.Where(u => u.RoleId == id).ToListAsync();
        var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
        if (userWhitRole.Count > 0) {
            return new ResponseResult {
                Msg = "امکان ویرایش نیست زیرا کاربرانی در سیستم با این نقش وجود دارند",
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

        role.RoleName = name;
        role.UpdatedAtDate = DateTime.Now.ToPersianDate();
        await _context.SaveChangesAsync();
        return new ResponseResult {
            Msg = "نقش بروزرسانی شد",
            StatusCode = (int)HttpStatusCode.OK,
            IsSuccess = true
        };
    }
}