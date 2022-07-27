using Microsoft.AspNetCore.Http;

namespace TaskManagerSolution.Application.Services.Commands.UserServices.UpdateUser;

public class UpdateUserDto {
    public string Name { get; set; }
    public string Phone { get; set; }
    public IFormFile? Img { get; set; }
}