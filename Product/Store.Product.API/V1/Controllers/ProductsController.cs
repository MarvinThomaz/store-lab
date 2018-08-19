<<<<<<< HEAD
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Common.Entities;
using Store.Common.Infra;
using Store.Common.List;
using Store.Product.API.V1.Models.Request;
using Store.Product.API.V1.Models.Response;
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
            if (ModelState.IsValid)
            {
                await _service.UpdateProduct(key, request.Name);

                return Ok();
            }

            return BadRequest();
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
        public async Task<IActionResult> GetProductByKeyAsync(string key, [FromServices] IMapper<ProductEntity, GetProductResponse> mapper)
        {
            var product = await _service.GetProductByKeyAsync(key);

            if(product == null)
            {
                return NotFound();
            }

            var response = mapper.Map(product);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync([FromQuery] PagingParameters parameters, [FromServices] IMapper<IPagingList<Domain.Entities.Product>, IPagingList<ListProductResponse>> mapper)
        {
            var list = await _service.GetProductsAsync(parameters.Page, parameters.RecordsPerPage);
            var result = mapper.Map(list);

            return Ok(result);
        }
    }
=======
using Microsoft.AspNetCore.Mvc;
using Store.Common.Extensions;
using Store.Common.Paging;
using Store.Product.API.V1.ModelExamples;
using Store.Product.Domain.Services;
using Store.Product.Presentation.V1.Mappers.Interfaces;
using Store.Product.Presentation.V1.Models.Request;
using Swashbuckle.AspNetCore.Examples;
using System.Threading.Tasks;

namespace Store.Product.API.V1.Controllers
{
    /// <summary>
    /// Controller of products to manage products of Store.
    /// </summary>
    [Route("v1/[controller]")]
    public class ProductsController : Controller
    {
        private const string GetProductRouteName = "GetProduct";

        private readonly IProductApplicationService _service;
        private readonly IUrlHelper _urlHelper;

        /// <summary>
        /// Initialize controller with service application and url helper.
        /// </summary>
        /// <param name="service">Service application used to manage products.</param>
        /// <param name="urlHelper">Url helper user to build links of members.</param>
        public ProductsController(IProductApplicationService service, IUrlHelper urlHelper)
        {
            _service = service;
            _urlHelper = urlHelper;
        }
        
        /// <summary>
        /// Create product asynchronously.
        /// </summary>
        /// <remarks>
        /// Creates a new product and insert in catalog of Store.
        /// </remarks>
        /// <param name="request">
        /// To create a product is important you have a <see cref="CreatePriceRequest"/> of product,
        /// and price have a <see cref="CreateCoinRequest"/> to create.
        /// Is optional to use <see cref="CreatePropertyRequest"/> and <see cref="LaunchsController"/>,
        /// but this types are list.
        /// </param>
        /// <param name="mapper">Map <see cref="CreateProductRequest"/> to <see cref="Domain.Entities.Product"/>.</param>
        /// <returns>Status of operation</returns>
        [HttpPost]
        [SwaggerResponseExample(201, typeof(CreateProductRequestExample))]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductRequest request, [FromServices] ICreateProductRequestToProductMapper mapper)
        {
            ModelState.Validate();

            var product = mapper.Map(request);

            await _service.RegisterNewProductAsync(product, request.Photos, request.ProfilePhoto);

            var urlParameters = new { controller = "products", key = product.Key };
            var link = _urlHelper.Link(GetProductRouteName, urlParameters);

            return Created(link, link);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{key}")]
        public async Task<IActionResult> DisableProductAsync(string key)
        {
            await _service.DisableProductAsync(key);

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync([FromQuery] PagingParameters parameters, [FromServices] IProductToListProductResponseMapper mapper)
        {
            var list = await _service.GetProductsAsync(parameters.Page, parameters.RercordsPerPage);
            var result = mapper.Map(list);

            return Ok(result);
        }
    }
>>>>>>> f04bd6248628029a6dbb2b819a33894afafd1103
}