using Microsoft.AspNetCore.Http;

namespace TaskManagerSolution.Application.Services.Commands.UserServices.RegisterUser;

public class RegisterUserDto
{
    public string UserName { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string RePassword { get; set; }
    public string Phone { get; set; }
    public IFormFile? Img { get; set; }
    public bool IsActive { get; set; }
}