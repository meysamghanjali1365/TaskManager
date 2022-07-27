using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Commands.UserServices.ChangeUserStatus;

public interface IChangeUserStatusService
{
    Task<ResponseResult> ChangeUserStatus(int id);
}