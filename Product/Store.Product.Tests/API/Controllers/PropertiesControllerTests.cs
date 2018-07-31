using System.Threading.Tasks;
using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Store.Common.Config;
using Store.Common.Infra;
using Store.Product.API.V1.Controllers;
using Store.Product.API.V1.Mappers;
using Store.Product.API.V1.Models.Request;
using Store.Product.Domain.Entities;
using Store.Product.Domain.Services;
using Xunit;

namespace Store.Product.Tests.API.Controllers
{
    public class PropertiesControllerTests
    {
        private readonly IProductApplicationService _service = Substitute.For<IProductApplicationService>();
        private readonly IUrlHelper _urlHelper = Substitute.For<IUrlHelper>();

        [Fact]
        public async Task AddOrUpdateProperty()
        {
            var controller = new PropertiesController(_service, _urlHelper);
            var key = KeyGenerator.New();
            var request = Builder<CreatePropertyRequest>.CreateNew().Build();
            var mapper = Substitute.For<IMapper<CreatePropertyRequest, Property>>();
            var property = Builder<Property>.CreateNew().Build();

            mapper.Map(request).Returns(property);

            _urlHelper.Link(Arg.Any<string>(), Arg.Any<object>()).Returns("");

            var result = await controller.AddOrUpdatePropertyAsync(key, request, mapper);

            mapper.Received(1).Map(request);
            
            await _service.Received(1).AddOrUpdatePropertyAsync(property, key);

            _urlHelper.Received(1).Link(Arg.Any<string>(), Arg.Any<object>());

            Assert.IsType<CreatedResult>(result);
        }
    }
}