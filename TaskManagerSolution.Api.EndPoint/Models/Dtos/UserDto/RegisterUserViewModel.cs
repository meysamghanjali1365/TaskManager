using System.ComponentModel.DataAnnotations;

namespace TaskManagerSolution.Api.EndPoint.Models.Dtos.UserDto;

public class RegisterUserViewModel {
    public string UserName { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string RePassword { get; set; }
    public string Phone { get; set; }
    public IFormFile? Img { get; set; }
}