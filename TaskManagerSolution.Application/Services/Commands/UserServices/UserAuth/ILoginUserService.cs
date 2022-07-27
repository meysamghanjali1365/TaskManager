using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Commands.UserServices.UserAuth;

public interface ILoginUserService
{
    Task<ResponseResult<ResultUserloginDto>> LoginUser(string username, string password);
}