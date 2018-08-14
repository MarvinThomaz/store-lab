using Microsoft.AspNetCore.Mvc;
using Store.Product.Domain.Enums;
using Store.Product.Presentation.V1.Mappers.Interfaces;

namespace Store.Product.API.V1.Controllers
{
    [Route("v1/[controller]")]
    public class LaunchsController : Controller
    {
        [HttpGet]
        [Route("types")]
        public IActionResult GetLaunchTypes([FromServices] ILaunchEnumToLaunchTypesMapper mapper)
        {
            return Ok(mapper.Map());
        }
    }
}
