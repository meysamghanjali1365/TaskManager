using System.Net;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Common.FileTool;
using TaskManagerSolution.Common.PasswordTool;
using TaskManagerSolution.Common.ResponseTool;
using TaskManagerSolution.Domain.Entities.AuthEntities;

namespace TaskManagerSolution.Application.Services.Commands.UserServices.RegisterUser;

public class RegisterUserService : IRegisterUserService {
    private readonly IDataBaseContext _context;
    private IHostingEnvironment _environment;
    public RegisterUserService(IDataBaseContext context, IHostingEnvironment environment) {
        _context = context;
        _environment = environment;
    }
    public async Task<ResponseResult> RegisterUser(RegisterUserDto registerUserDto) {
        UploadHelper UploadObj = new UploadHelper(_environment);
        var uploadedResultImg = UploadObj.UploadFile(registerUserDto.Img, $@"avatar\");
        var userWithUserName = await _context.Users.FirstOrDefaultAsync(u => u.UserName == registerUserDto.UserName || u.Phone == registerUserDto.Phone);
        if (userWithUserName != null) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "این نام کاربری یا شماره همراه قبلا توسط کاربر دیگری استفاده شده است",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        if (string.IsNullOrWhiteSpace(registerUserDto.UserName)) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "نام کاربری را وارد کنید",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        if (registerUserDto.UserName.Contains(" ")) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "نام کاربری نباید دارای فاصله باشد",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        if (string.IsNullOrWhiteSpace(registerUserDto.Name)) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "نام  را وارد کنید",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        if (string.IsNullOrWhiteSpace(registerUserDto.Password)) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "کلمه عبور را وارد کنید",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        if (registerUserDto.Password != registerUserDto.RePassword) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "کلمه عبور با تکرار آن برابر نیست",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        if (registerUserDto.Phone.Length < 10 || registerUserDto.Phone.Length > 10) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "تلفن همراه باید 10 رقم باشد",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        if (registerUserDto.Password.Length < 6 ) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "کلمه عبور باید حداقل 6 کاراکتر باشد",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        if (string.IsNullOrWhiteSpace(registerUserDto.Phone)) {
            return new ResponseResult() {
                IsSuccess = false,
                Msg = "تلفن همراهرا وارد کنید",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        var passwordHasher = new PasswordHasher();
        var hashedPassword = passwordHasher.HashPassword(registerUserDto.Password);

        try {

            User user = new User();
            user.Name = registerUserDto.Name;
            user.UserName = registerUserDto.UserName;
            user.Password = hashedPassword;
            user.IsActive = true;
            user.RoleId = 2;
            user.Phone = registerUserDto.Phone;
            if (registerUserDto.Img != null) {
                user.AvatarPath = uploadedResultImg.FileNameAddress;
            }
            if (registerUserDto.Img == null) {
                user.AvatarPath = "";
            }
            _context.Users.Add(user);
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