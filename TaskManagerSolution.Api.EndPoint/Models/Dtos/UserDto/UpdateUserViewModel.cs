namespace TaskManagerSolution.Api.EndPoint.Models.Dtos.UserDto;

public class UpdateUserViewModel
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public IFormFile? Img { get; set; }
}