using System.Net;
using Microsoft.EntityFrameworkCore;
using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Common.ResponseTool;

namespace TaskManagerSolution.Application.Services.Queries.RoleService.GetAllRole;

public class GetAllRoleService : IGetAllRoleService {
    private readonly IDataBaseContext _context;

    public GetAllRoleService(IDataBaseContext context) {
        _context = context;
    }

    public async Task<ResponseResult<List<GetAllRoleDto>>> GetAllRole(string? searchKey) {
        var role = _context.Roles.AsQueryable();
        if (!string.IsNullOrWhiteSpace(searchKey)) {
            role = role.Where(r => r.RoleName.Contains(searchKey));
        }
        var roleList = await role.Select(r => new GetAllRoleDto() {
            Name = r.RoleName,
            CreateAtDate = r.CreatedAtDate,
            Id = r.Id
        }).ToListAsync();
        return new ResponseResult<List<GetAllRoleDto>>() {
            Result = roleList,
            StatusCode = (int)HttpStatusCode.OK,
            IsSuccess = true
        };
    }
}