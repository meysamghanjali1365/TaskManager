using System.Net;
using Microsoft.EntityFrameworkCore;
using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Queries.UserServices.GetUser;

public class GetUserService : IGetUserService {
    private readonly IDataBaseContext _context;

    public GetUserService(IDataBaseContext context)
    {
        _context = context;
    }

    public async Task<ResponseResult<List<GetUserDto>>> GetUsers(string? searchKey) {
        var users = _context.Users
            .Include(i => i.Role)
            .AsQueryable();
        if (!string.IsNullOrWhiteSpace(searchKey)) {
            users = users.Where(u => u.Name.Contains(searchKey) || u.UserName.Contains(searchKey)).AsQueryable();
        }

        var listUser = await users.Select(u => new GetUserDto() {
            UserName = u.UserName,
            Phone = u.Phone,
            AvatarPath = u.AvatarPath,
            Name = u.Name,
            IsActive = u.IsActive,
            CreatedAtDate = u.CreatedAtDate,
            Id = u.Id,
            RoleName = u.Role.RoleName
        }).ToListAsync();
        return new ResponseResult<List<GetUserDto>>() {
            Result = listUser,
            IsSuccess = true,
            StatusCode = (int)HttpStatusCode.OK,
            Msg = ""
        };
    }
}