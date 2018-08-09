using Microsoft.AspNetCore.Mvc;
using Store.Common.Infra;
using Store.Product.API.V1.Models.Response;
using Store.Product.Domain.Enums;
using System.Collections.Generic;

namespace Store.Product.API.V1.Controllers
{
    [Route("v1/[controller]")]
    public class LaunchsController : Controller
    {
        [HttpGet]
        [Route("types")]
        public IActionResult GetLaunchTypes([FromServices] IMapper<LaunchEnum, IEnumerable<LaunchTypesResponse>> mapper)
        {
            return Ok(mapper.Map(LaunchEnum.Addition));
        }
    }
}
