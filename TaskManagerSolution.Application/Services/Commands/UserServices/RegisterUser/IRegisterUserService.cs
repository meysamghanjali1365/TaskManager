using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Commands.UserServices.RegisterUser;

public interface IRegisterUserService {
    Task<ResponseResult> RegisterUser(RegisterUserDto registerUserDto);
}