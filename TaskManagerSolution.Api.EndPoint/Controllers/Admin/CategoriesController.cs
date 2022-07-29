using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Swashbuckle.Swagger.Annotations;
using TaskManagerSolution.Api.EndPoint.Models.Dtos.CategoryDto;
using TaskManagerSolution.Application.Interfaces.IFasde;

namespace TaskManagerSolution.Api.EndPoint.Controllers.Admin {
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase {
        private readonly ICategoryFasade _category;
        public CategoriesController(ICategoryFasade category) {
            _category = category;
        }

        [HttpGet]
        [Route("/api/admin/get_categories/{key?}")]
        public async Task<IActionResult> GetCategories([Optional]string key) {
            var res = _category.GetAllCategoryService.GetCategories(key).Result;
            return Ok(res);
        }
        [HttpPost]
        [Route("/api/admin/create_category")]
        public async Task<IActionResult> PostCategory([FromBody] CreateCategoryDto category) {
            var res = await _category.CreateCategoryService.CreateCategory(category.Name);
            return Ok(res);
        }
    }
}
