using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerSolution.Api.EndPoint.Models.Dtos.RoleDto;
using TaskManagerSolution.Application.Interfaces.IFasde;

namespace TaskManagerSolution.Api.EndPoint.Controllers {
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleFasade _roleFasade;

        public RoleController(IRoleFasade roleFasade)
        {
            _roleFasade = roleFasade;
        }

        [HttpPost]
        public async Task<IActionResult> PostRole([FromBody] CreateRoleViewModel role)
        {
            var res = await _roleFasade.RoleCreateService.CreateRole(role.Name);
            return Ok(res);
        }
    }
}
