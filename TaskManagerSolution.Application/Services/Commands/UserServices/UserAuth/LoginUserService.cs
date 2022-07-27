using System.Linq;
using System.Net;
using Microsoft.EntityFrameworkCore;
using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Common.PasswordTool;
using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Commands.UserServices.UserAuth;

public class LoginUserService : ILoginUserService
{
    private readonly IDataBaseContext _context;

    public LoginUserService(IDataBaseContext context)
    {
        _context = context;
    }

    public async Task<ResponseResult<ResultUserloginDto>> LoginUser(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            return new ResponseResult<ResultUserloginDto>()
            {
                Result = null,
                IsSuccess = false,
                StatusCode = (int) HttpStatusCode.BadRequest,
                Msg = "نام کاربری یا کلمه عبور وارد نشده"
            };
        }
        var user = await _context.Users.Include(p => p.Role)
            .FirstOrDefaultAsync(p => (p.UserName.Equals(username))
                                 && p.IsActive == true);

        if (user == null) {
            return new ResponseResult<ResultUserloginDto>() {
                Result = null,
                IsSuccess = false,
                StatusCode = (int)HttpStatusCode.NotFound,
                Msg = "کاربر با این مشخصات یافت نشد"
            };
        }

        var passwordHasher = new PasswordHasher();
        bool resultVerifyPassword = passwordHasher.VerifyPassword(user.Password, password);
        if (resultVerifyPassword == false) {
            return new ResponseResult<ResultUserloginDto>() {
                Result = null,
                IsSuccess = false,
                StatusCode = (int)HttpStatusCode.NotFound,
                Msg = "کلمه عبور صحیح نیست"
            };
        }
        return new ResponseResult<ResultUserloginDto>() {
            Result = new ResultUserloginDto
            {
                Role = user.Role.RoleName,
                UserId = user.Id,
                Name = user.Name
            },
            IsSuccess = true,
            StatusCode = (int)HttpStatusCode.OK,
            Msg = ""
        };
    }
}