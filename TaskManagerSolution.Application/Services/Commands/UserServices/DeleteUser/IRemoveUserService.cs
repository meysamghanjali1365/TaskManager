using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Commands.UserServices.DeleteUser;

public interface IRemoveUserService
{
    Task<ResponseResult> DeleteUser(int id);
}