using System.Net;
using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Common.ResponseTool;
using TaskManagerSolution.Common.Setting;
using TaskManagerSolution.Domain.Entities.SysLog;

namespace TaskManagerSolution.Application.Services.Commands.UserServices.ChangeUserStatus;

public class ChangeUserStatusService : IChangeUserStatusService {
    private readonly IDataBaseContext _context;

    public ChangeUserStatusService(IDataBaseContext context) {
        _context = context;
    }

    public async Task<ResponseResult> ChangeUserStatus(int id) {
        var user = await _context.Users.FindAsync(id);
        if (user == null) {
            return new ResponseResult {
                StatusCode = (int)HttpStatusCode.NotFound,
                Msg = "کاربر یافت نشد",
                IsSuccess = false,
            };
        }

        user.IsActive = !user.IsActive;
        string userstate = user.IsActive == true ? "فعال" : "غیر فعال";
        await _context.SaveChangesAsync();
 
        return new ResponseResult {
            StatusCode = (int)HttpStatusCode.OK,
            Msg = user.Name + userstate + " " + "شد",
            IsSuccess = true,
        };
    }
}