using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Commands.UserServices.RegisterUserbyAdmin;

public interface IAdminRegisterUserService
{
    Task<ResponseResult> AdminUserCreateor(RegisterUserDtoByAdmin user);
}