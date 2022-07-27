using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Common.ResponseTool;
using TaskManagerSolution.Common.FileTool;
using System.Net;
using TaskManagerSolution.Common.PasswordTool;
using TaskManagerSolution.Domain.Entities.AuthEntities;

namespace TaskManagerSolution.Application.Services.Commands.UserServices.RegisterUserbyAdmin;

public class AdminRegisterUserService : IAdminRegisterUserService {
    private readonly IDataBaseContext _context;
    private IHostingEnvironment _environment;

    public AdminRegisterUserService(IDataBaseContext context, IHostingEnvironment environment) {
        _context = context;
        _environment = environment;
    }

    public async Task<ResponseResult> AdminUserCreateor(RegisterUserDtoByAdmin user) {
        UploadHelper UploadObj = new UploadHelper(_environment);
        var uploadedResultImg = UploadObj.UploadFile(user.Img, $@"avatar\");
        var userWithUserName = await _context.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName || u.Phone == user.Phone);
        var role = await _context.Roles.FindAsync(user.RoleId);
        if (role == null) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "این نقش در سیستم وجود ندارد",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        if (userWithUserName != null) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "این نام کاربری یا شماره همراه قبلا توسط کاربر دیگری استفاده شده است",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        if (string.IsNullOrWhiteSpace(user.UserName)) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "نام کاربری را وارد کنید",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        if (user.UserName.Contains(" ")) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "نام کاربری نباید دارای فاصله باشد",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        if (string.IsNullOrWhiteSpace(user.Name)) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "نام  را وارد کنید",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        if (string.IsNullOrWhiteSpace(user.Password)) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "کلمه عبور را وارد کنید",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        if (user.Password != user.RePassword) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "کلمه عبور با تکرار آن برابر نیست",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        if (user.Phone.Length < 11 || user.Phone.Length > 20) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "تلفن همراه باید 11 رقم باشد",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        if (user.Password.Length < 6) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "کلمه عبور باید حداقل 6 کاراکتر باشد",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        if (string.IsNullOrWhiteSpace(user.Phone)) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "تلفن همراهرا وارد کنید",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        var passwordHasher = new PasswordHasher();
        var hashedPassword = passwordHasher.HashPassword(user.Password);

        try {

            User userObj = new User();
            userObj.Name = user.Name;
            userObj.UserName = user.UserName;
            userObj.Password = hashedPassword;
            userObj.IsActive = user.IsActive;
            userObj.RoleId = 2;
            userObj.Phone = user.Phone;
            if (user.Img != null) {
                userObj.AvatarPath = uploadedResultImg.FileNameAddress;
            }
            if (user.Img == null) {
                userObj.AvatarPath = "";
            }
            userObj.Role = role;
            userObj.RoleId = role.Id;
            _context.Users.Add(userObj);
            await _context.SaveChangesAsync();

            return new ResponseResult() {
                IsSuccess = true,
                Msg = "شما در سیستم ثبت نام شدید",
                StatusCode = (int)HttpStatusCode.OK
            };
        } catch (Exception ex) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = ex.Message,
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
    }
}