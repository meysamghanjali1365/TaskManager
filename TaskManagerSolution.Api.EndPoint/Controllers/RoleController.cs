using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerSolution.Api.EndPoint.Models.Dtos.RoleDto;
using TaskManagerSolution.Application.Interfaces.IFasde;

namespace TaskManagerSolution.Api.EndPoint.Controllers {
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase {
        private readonly IRoleFasade _roleFasade;
        public RoleController(IRoleFasade roleFasade) {
            _roleFasade = roleFasade;
        }

        [HttpGet]
        [Route("/api/role/get_roles")]
        public async Task<IActionResult> GetRole(string? key) {
            var res = await _roleFasade.GetAllRoleService.GetAllRole(key);
            return Ok(res);
        }
        [HttpPost]
        [Route("/api/role/create_role")]
        public async Task<IActionResult> PostRole([FromBody] CreateRoleViewModel role) {
            var res = await _roleFasade.RoleCreateService.CreateRole(role.Name);
            return Ok(res);
        }

        [HttpDelete]
        [Route("/api/role/remove_role/{id}")]
        public async Task<IActionResult> DeleteRole([FromRoute] int id) {
            var res = await _roleFasade.RemoveRoleService.DeleteRole(id);
            return Ok(res);
        }

        [HttpPut]
        [Route("/api/role/edit_role/{id}")]
        public async Task<IActionResult> PutRole([FromRoute] int id, [FromBody] EditRoleViewModel role) {
            var res = await _roleFasade.UpdateRoleService.EditRoleName(id, role.Name);
            return Ok(res);
        }
    }
}
