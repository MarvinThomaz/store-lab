using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Store.Common.Infra;
using Store.Product.API.V1.Controllers;
using Store.Product.API.V1.Models.Request;
using Store.Product.Domain.Services;
using System.Threading.Tasks;
using Xunit;
using ProductEntity = Store.Product.Domain.Entities.Product;

namespace Store.Product.Tests.Unit.API.Controllers
{
    public class ProductsControllerTests
    {
        private readonly IProductApplicationService _service = Substitute.For<IProductApplicationService>();
        private readonly IUrlHelper _urlHelper = Substitute.For<IUrlHelper>();
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            _controller = new ProductsController(_service, _urlHelper);
        }

        [Fact]
        public async Task CreateProductTest()
        {
            var createProductMapper = Substitute.For<IMapper<CreateProductRequest, ProductEntity>>();
            var request = Builder<CreateProductRequest>.CreateNew().Build();
            var product = Builder<ProductEntity>.CreateNew().Build();

            createProductMapper.Map(request).Returns(product);

            _urlHelper.Link(Arg.Any<string>(), Arg.Any<object>()).Returns("");                

            var result = await _controller.CreateProductAsync(request, createProductMapper);

            createProductMapper.Received(1).Map(request);

            await _service.Received(1).RegisterNewProductAsync(product);

            _urlHelper.Received(1).Link(Arg.Any<string>(), Arg.Any<object>()); 

            Assert.IsType<CreatedResult>(result);
        }
    }
}