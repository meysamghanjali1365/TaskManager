using Microsoft.AspNetCore.Http;
using TaskManagerSolution.Domain.Entities.AuthEntities;

namespace TaskManagerSolution.Application.Services.Commands.UserServices.RegisterUserbyAdmin;

public class RegisterUserDtoByAdmin {
    public string UserName { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string RePassword { get; set; }
    public string Phone { get; set; }
    public IFormFile? Img { get; set; }
    public bool IsActive { get; set; }
    public int RoleId { get; set; }
}