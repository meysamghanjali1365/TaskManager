using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Common.FileTool;
using TaskManagerSolution.Common.ResponseTool;
using TaskManagerSolution.Common.Setting;
using TaskManagerSolution.Domain.Entities.SysLog;

namespace TaskManagerSolution.Application.Services.Commands.UserServices.DeleteUser;

public class RemoveUserService : IRemoveUserService {
    private readonly IDataBaseContext _context;
    private IHostingEnvironment _environment;

    public RemoveUserService(IDataBaseContext context, IHostingEnvironment environment) {
        _context = context;
        _environment = environment;
    }

    public async Task<ResponseResult> DeleteUser(int id) {
        var user = await _context.Users.FindAsync(id);
        if (user == null) {
            return new ResponseResult {
                Msg = "کاربر یافت نشد",
                StatusCode = (int)HttpStatusCode.NotFound,
                IsSuccess = false
            };
        }
        if (!string.IsNullOrWhiteSpace(user.AvatarPath)) {
            var userImagesPath = Path.Combine(_environment.WebRootPath, user.AvatarPath);
            DeleteFile.DeleteFileFromRoot(@userImagesPath);
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return new ResponseResult {
            Msg = "کاربر با موفقیت از سیستم حذف شد",
            StatusCode = (int)HttpStatusCode.OK,
            IsSuccess = true
        };
    }
}