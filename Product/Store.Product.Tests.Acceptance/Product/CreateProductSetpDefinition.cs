using NSubstitute;
using Store.Product.Application.Services;
using Store.Product.Domain.Entities;
using Store.Product.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;
using ProductEntity = Store.Product.Domain.Entities.Product;

namespace Store.Product.Tests.Acceptance.Product
{
    [Binding]
    public sealed class CreateProductSetpDefinition
    {
        private ProductEntity _product;
        private ProductEntity _savedProduct;

        [Given(@"That the product was create with data")]
        public void GivenThatTheProductWasCreateWithData(Table productTable)
        {
            _product = productTable.CreateInstance<ProductEntity>();
        }

        [Given(@"The product have this properties")]
        public void GivenTheProductHaveThisProperties(Table propertiesTable)
        {
            _product.Properties = propertiesTable.CreateSet<Property>().ToList();
        }

        [When(@"I save the product in database")]
        public async Task WhenISaveTheProductInDatabase()
        {
            var repository = Substitute.For<IProductRepository>();
            var service = new ProductApplicationService(repository);

            await service.RegisterNewProductAsync(_product);

            ScenarioContext.Current.Set(_product);
        }

        [Then(@"the result should be a object created")]
        public void ThenTheResultShouldBeAObjectCreated(Table productTable)
        {
            _savedProduct = productTable.CreateInstance<ProductEntity>();

            Assert.Equal(_product.Code, _savedProduct.Code);
            Assert.Equal(_product.Name, _savedProduct.Name);
            Assert.Equal(_product.IsEnabled, _savedProduct.IsEnabled);
        }

        [Then(@"the properties of product is")]
        public void ThenThePropertiesOfProductIs(Table propertiesTable)
        {
            _savedProduct.Properties = propertiesTable.CreateSet<Property>().ToList();

            Assert.Equal(_product.Code, _savedProduct.Code);
            Assert.Equal(_product.Name, _savedProduct.Name);
            Assert.Equal(_product.IsEnabled, _savedProduct.IsEnabled);

            for (int i = 0; i < _product.Properties.Count; i++)
            {
                var property = _product.Properties[i];
                var savedProperty = _savedProduct.Properties[i];

                Assert.Equal(property.Name, savedProperty.Name);
                Assert.Equal(property.Value, savedProperty.Value);
            }
        }
    }
}
