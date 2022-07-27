using System.Net;
using Microsoft.AspNetCore.Hosting;
using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Common.DateTool;
using TaskManagerSolution.Common.FileTool;
using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Commands.UserServices.UpdateUser;

public class EditUserService : IEditUserService {
    private readonly IDataBaseContext _context;
    private IHostingEnvironment _environment;

    public EditUserService(IDataBaseContext context, IHostingEnvironment environment) {
        _context = context;
        _environment = environment;
    }
    public async Task<ResponseResult> EditUser(int id, UpdateUserDto updateUserDto) {
        var user = await _context.Users.FindAsync(id);
        if (user == null) {
            return new ResponseResult() {
                Msg = "کاربر یافت نشد",
                StatusCode = (int)HttpStatusCode.NotFound,
                IsSuccess = false
            };
        }
        if (updateUserDto.Img != null) {
            UploadHelper UploadObj = new UploadHelper(_environment);
            var uploadedResultImg = UploadObj.UploadFile(updateUserDto.Img, $@"avatar\");
            if (!string.IsNullOrWhiteSpace(user.AvatarPath)) {
                var userImagesPath = Path.Combine(_environment.WebRootPath, user.AvatarPath);
                DeleteFile.DeleteFileFromRoot(@userImagesPath);
            }
            user.AvatarPath = uploadedResultImg.FileNameAddress;
        }
        user.Name = updateUserDto.Name;
        user.Phone = updateUserDto.Phone;
        user.UpdatedAtDate = DateTime.Now.ToPersianDate();
        await _context.SaveChangesAsync();
        return new ResponseResult
        {
            Msg = "کاربر بروزرسانی شد",
            StatusCode = (int)HttpStatusCode.OK,
            IsSuccess = true
        };
    }
}