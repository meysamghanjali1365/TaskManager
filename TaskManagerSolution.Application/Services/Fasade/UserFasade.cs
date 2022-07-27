using Microsoft.AspNetCore.Hosting;
using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Application.Interfaces.IFasde;
using TaskManagerSolution.Application.Services.Commands.UserServices.ChangeUserStatus;
using TaskManagerSolution.Application.Services.Commands.UserServices.DeleteUser;
using TaskManagerSolution.Application.Services.Commands.UserServices.RegisterUser;
using TaskManagerSolution.Application.Services.Commands.UserServices.RegisterUserbyAdmin;
using TaskManagerSolution.Application.Services.Commands.UserServices.UpdateUser;
using TaskManagerSolution.Application.Services.Commands.UserServices.UserAuth;
using TaskManagerSolution.Application.Services.Queries.UserServices.GetUser;

namespace TaskManagerSolution.Application.Services.Fasade;

public class UserFasade : IUserFasade {
    private readonly IHostingEnvironment _environment;
    private readonly IDataBaseContext _context;

    public UserFasade(IHostingEnvironment environment, IDataBaseContext context) {
        _environment = environment;
        _context = context;
    }
    private IRegisterUserService _registerUserService;
    public IRegisterUserService RegisterUserService {
        get {
            return _registerUserService = _registerUserService ?? new RegisterUserService(_context, _environment);
        }
    }
    private IGetUserService _getUserService;
    public IGetUserService GetGetUserService {
        get {
            return _getUserService = _getUserService ?? new GetUserService(_context);
        }
    }
    private ILoginUserService _loginUserService;
    public ILoginUserService LoginUserService {
        get {
            return _loginUserService = _loginUserService ?? new LoginUserService(_context);
        }
    }
    private IEditUserService _editUserService;
    public IEditUserService EditUserService {
        get {
            return _editUserService = _editUserService ?? new EditUserService(_context, _environment);
        }
    }
    private IChangeUserStatusService _changeUserStatusService;
    public IChangeUserStatusService ChangeUserStatusService {
        get {
            return _changeUserStatusService = _changeUserStatusService ?? new ChangeUserStatusService(_context);
        }
    }
    private IRemoveUserService _removeUserService;
    public IRemoveUserService RemoveUserService {
        get {
            return _removeUserService = _removeUserService ?? new RemoveUserService(_context, _environment);
        }
    }
    private IAdminRegisterUserService _adminRegisterUserService;
    public IAdminRegisterUserService AdminRegisterUserService {
        get {
            return _adminRegisterUserService =
                _adminRegisterUserService ?? new AdminRegisterUserService(_context, _environment);
        }
    }
}