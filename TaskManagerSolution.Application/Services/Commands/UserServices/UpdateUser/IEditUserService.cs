using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Commands.UserServices.UpdateUser;

public interface IEditUserService
{
    Task<ResponseResult> EditUser(int id, UpdateUserDto updateUserDto);
}