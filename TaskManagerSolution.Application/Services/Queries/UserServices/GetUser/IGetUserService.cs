using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Queries.UserServices.GetUser;

public interface IGetUserService
{
    Task<ResponseResult<List<GetUserDto>>> GetUsers(string? searchKey);
}