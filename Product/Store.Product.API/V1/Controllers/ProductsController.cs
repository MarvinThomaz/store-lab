using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Common.Entities;
using Store.Common.Infra;
using Store.Product.API.V1.Models.Request;
using Store.Product.Domain.Services;
using ProductEntity = Store.Product.Domain.Entities.Product;

namespace Store.Product.API.V1.Controllers
{
    [Route("v1/[controller]")]
    public class ProductsController : Controller
    {
        private const string GetProductRouteName = "GetProduct";

        private readonly IProductApplicationService _service;
        private readonly IUrlHelper _urlHelper;

        public ProductsController(IProductApplicationService service, IUrlHelper urlHelper)
        {
            _service = service;
            _urlHelper = urlHelper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductRequest request, [FromServices] IMapper<CreateProductRequest, ProductEntity> mapper)
        {
            if(ModelState.IsValid)
            {
                var product = mapper.Map(request);

                await _service.RegisterNewProductAsync(product);
                
                var urlParameters = new { controller = "products", key = product.Key };
                var link = _urlHelper.Link(GetProductRouteName, urlParameters);

                return Created(link, link);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("{key}")]
        public async Task<IActionResult> UpdateProductAsync(string key, [FromBody] UpdateProductRequest request, [FromServices] IMapper<UpdateProductRequest, ProductEntity> mapper)
        {
            var product = mapper.Map(request);

            product.Key = key;

            await _service.UpdateProduct(product, key);

            return Ok();
        }

        [HttpDelete]
        [Route("{key}")]
        public async Task<IActionResult> DisableProduct(string key)
        {
            await _service.DisableProduct(key);

            return NoContent();
        }

        [HttpGet]
        [Route("{key}", Name = GetProductRouteName)]
        public async Task<IActionResult> GetProductAsync(string key)
        {
            var product = await _service.GetProductByKeyAsync(key);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync([FromQuery] PagingParameters parameters)
        {
            var list = await _service.GetProductsAsync(parameters.Page, parameters.RercordsPerPage);

            return Ok(list);
        }
    }
}