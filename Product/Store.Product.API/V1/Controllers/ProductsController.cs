using Microsoft.AspNetCore.Mvc;
using Store.Common.Extensions;
using Store.Common.Paging;
using Store.Product.Domain.Services;
using Store.Product.Presentation.V1.Mappers.Interfaces;
using Store.Product.Presentation.V1.Models.Request;
using System.Threading.Tasks;

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
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductRequest request, [FromServices] ICreateProductRequestToProductMapper mapper)
        {
            ModelState.Validate();

            var product = mapper.Map(request);

            await _service.RegisterNewProductAsync(product, request.Photos, request.ProfilePhoto);

            var urlParameters = new { controller = "products", key = product.Key };
            var link = _urlHelper.Link(GetProductRouteName, urlParameters);

            return Created(link, link);
        }

        [HttpDelete]
        [Route("{key}")]
        public async Task<IActionResult> DisableProduct(string key)
        {
            await _service.DisableProductAsync(key);

            return NoContent();
        }

        [HttpGet]
        [Route("{key}", Name = GetProductRouteName)]
        public async Task<IActionResult> GetProductAsync(string key)
        {
            var product = await _service.GetProductByKeyAsync(key);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync([FromQuery] PagingParameters parameters, [FromServices] IProductToListProductResponseMapper mapper)
        {
            var list = await _service.GetProductsAsync(parameters.Page, parameters.RercordsPerPage);
            var result = mapper.Map(list);

            return Ok(result);
        }
    }
}