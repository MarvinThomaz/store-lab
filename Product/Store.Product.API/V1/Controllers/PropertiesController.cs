using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Common.Infra;
using Store.Product.API.V1.Mappers;
using Store.Product.API.V1.Models.Request;
using Store.Product.Domain.Entities;
using Store.Product.Domain.Services;

namespace Store.Product.API.V1.Controllers
{
    [Route("v1/products/{key}/[controller]")]
    public class PropertiesController : Controller
    {
        public const string GetPropertiesByProductRouteName = "GetPropertiesByProduct";

        private readonly IUrlHelper _urlHelper;
        private readonly IProductApplicationService _service;

        public PropertiesController(IProductApplicationService service, IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
            _service = service;
        }

        [HttpPost]
        [HttpPut]
        public async Task<IActionResult> AddOrUpdatePropertyAsync(string key, [FromBody] CreatePropertyRequest request, [FromServices] IMapper<CreatePropertyRequest, Property> mapper)
        {
            if(ModelState.IsValid)
            {
                var property = mapper.Map(request);

                await _service.AddOrUpdatePropertyAsync(property, key);

                var link = _urlHelper.Link(GetPropertiesByProductRouteName, new { controller = "properties", key = key });

                return Created(link, link);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("", Name = GetPropertiesByProductRouteName)]
        public async Task<IActionResult> GetPropertiesByProductAsync(string key)
        {
            var product = await _service.GetProductByKeyAsync(key);

            if (product != null)
            {
                return Ok(product.Properties);
            }

            return NotFound();
        }
    }
}