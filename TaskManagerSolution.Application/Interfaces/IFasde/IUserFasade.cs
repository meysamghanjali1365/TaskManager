using TaskManagerSolution.Application.Services.Commands.UserServices.ChangeUserStatus;
using TaskManagerSolution.Application.Services.Commands.UserServices.DeleteUser;
using TaskManagerSolution.Application.Services.Commands.UserServices.RegisterUser;
using TaskManagerSolution.Application.Services.Commands.UserServices.RegisterUserbyAdmin;
using TaskManagerSolution.Application.Services.Commands.UserServices.UpdateUser;
using TaskManagerSolution.Application.Services.Commands.UserServices.UserAuth;
using TaskManagerSolution.Application.Services.Queries.UserServices.GetUser;

namespace TaskManagerSolution.Application.Interfaces.IFasde;

public interface IUserFasade
{
   IRegisterUserService RegisterUserService { get; }
   IGetUserService GetGetUserService { get; }
   ILoginUserService LoginUserService { get; }
   IEditUserService EditUserService { get; }
   IChangeUserStatusService ChangeUserStatusService { get; }
   IRemoveUserService RemoveUserService { get; }
   IAdminRegisterUserService AdminRegisterUserService { get; }
}