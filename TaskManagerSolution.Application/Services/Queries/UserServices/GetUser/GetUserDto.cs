namespace TaskManagerSolution.Application.Services.Queries.UserServices.GetUser;

public class GetUserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Phone { get; set; }
    public string? AvatarPath { get; set; }
    public string CreatedAtDate { get; set; }
    public bool IsActive { get; set; }
    public string RoleName { get; set; }
}