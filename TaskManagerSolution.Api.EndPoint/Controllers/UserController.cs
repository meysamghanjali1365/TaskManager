using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerSolution.Api.EndPoint.Models.Dtos.UserDto;
using TaskManagerSolution.Application.Interfaces.IFasde;
using TaskManagerSolution.Application.Services.Commands.UserServices.RegisterUser;
using TaskManagerSolution.Application.Services.Commands.UserServices.RegisterUserbyAdmin;
using TaskManagerSolution.Application.Services.Commands.UserServices.UpdateUser;

namespace TaskManagerSolution.Api.EndPoint.Controllers {
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IUserFasade _user;
        public UserController(IUserFasade user) {
            _user = user;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("/api/user/get_all/{searchKey?}")]
        public async Task<IActionResult> GetUser([Optional]string searchKey) {
            var res =  _user.GetGetUserService.GetUsers(searchKey).Result;
            return Ok(res);
        }
        [HttpPost]
        [Route("/api/user/register")]
        public async Task<IActionResult> Register([FromForm] RegisterUserViewModel newUser) {
            var res = await _user.RegisterUserService.RegisterUser(new RegisterUserDto {
                Img = newUser.Img,
                Name = newUser.Name,
                Password = newUser.Password,
                RePassword = newUser.RePassword,
                Phone = newUser.Phone,
                UserName = newUser.UserName
            });
            return Ok(res);
        }
        [HttpPost]
        [Route("/api/user/admin_register_user")]
        public async Task<IActionResult> RegisterAdminUser([FromForm] CreateUserByAdminViewModel newUser) {
            var res = await _user.AdminRegisterUserService.AdminUserCreateor(new RegisterUserDtoByAdmin{
                Img = newUser.Img,
                Name = newUser.Name,
                Password = newUser.Password,
                RePassword = newUser.RePassword,
                Phone = newUser.Phone,
                UserName = newUser.UserName,
                IsActive = newUser.IsActive,
                RoleId = newUser.RoleId
            });
            return Ok(res);
        }
        [HttpPut]
        [Route("/api/user/edit_user/{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromForm] UpdateUserViewModel user) {
            var res = await _user.EditUserService.EditUser(id, new UpdateUserDto {
                Img = user.Img,
                Name = user.Name,
                Phone = user.Phone,
            });
            return Ok(res);
        }

        [HttpPost]
        [Route("/api/user/change_user_status/{id}")]
        public async Task<IActionResult> PostUserStatus([FromRoute] int id) {
            var res = await _user.ChangeUserStatusService.ChangeUserStatus(id);
            return Ok(res);
        }

        [HttpDelete]
        [Route("/api/user/remove_user/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var res = await _user.RemoveUserService.DeleteUser(id);
            return Ok(res);
        }
    }
}
