using System;
using System.Threading.Tasks;
using NSubstitute;
using Store.Common.Infra;
using Store.Product.Repositories;
using Xunit;
using FizzWare.NBuilder;

using ProductEntity = Store.Product.Domain.Entities.Product;
using Store.Product.Domain.Entities;
using Store.Common.Config;
using System.Linq;

namespace Store.Product.Tests.Repositories
{
    public class ProductRepositoryTests
    {
        private readonly IDataAccess _dataAccess = Substitute.For<IDataAccess>();

        [Fact]
        public async Task CreateProduct()
        {
            var repository = new ProductRepository(_dataAccess);
            var product = Builder<ProductEntity>.CreateNew().Build();

            await repository.CreateProductAsync(product);
            await _dataAccess.Received(1).InsertAsync(product);
        }

        [Fact]
        public async Task AddPropertyOnProdutWithoutProperties()
        {
            var repository = new ProductRepository(_dataAccess);
            var property = Builder<Property>.CreateNew().Build();
            var product = Builder<ProductEntity>.CreateNew().Build();

            _dataAccess.SelectByKeyAsync<ProductEntity>(product.Key).Returns(product);

            await repository.AddOrUpdatePropertyAsync(property, product.Key);

            await _dataAccess.Received(1).SelectByKeyAsync<ProductEntity>(product.Key);
            await _dataAccess.Received(1).UpdateAsync(product, product.Key);

            Assert.Same(product.Properties?.Last(), property);
        }

        [Fact]
        public async Task AddPropertyOnProdutWithProperties()
        {
            var repository = new ProductRepository(_dataAccess);
            var property = Builder<Property>.CreateNew().Build();
            var properties = Builder<Property>
                                .CreateListOfSize(2)
                                .All()
                                .With(p => p.Name, "Property")
                                .Build();

            var product = Builder<ProductEntity>
                                .CreateNew()
                                .With(p => p.Properties, properties)
                                .Build();

            _dataAccess.SelectByKeyAsync<ProductEntity>(product.Key).Returns(product);

            await repository.AddOrUpdatePropertyAsync(property, product.Key);

            await _dataAccess.Received(1).SelectByKeyAsync<ProductEntity>(product.Key);
            await _dataAccess.Received(1).UpdateAsync(product, product.Key);

            Assert.Same(product.Properties?.Last(), property);
        }

        [Fact]
        public async Task AddPropertyOnProdutWithSameProperty()
        {
            var repository = new ProductRepository(_dataAccess);
            var property = Builder<Property>
                                .CreateNew()
                                .With(p => p.Name, "Property")
                                .Build();

            var properties = Builder<Property>
                                .CreateListOfSize(1)
                                .All()
                                .With(p => p.Name, "Property")
                                .Build();

            var product = Builder<ProductEntity>
                                .CreateNew()
                                .With(p => p.Properties, properties)
                                .Build();

            _dataAccess.SelectByKeyAsync<ProductEntity>(product.Key).Returns(product);

            await repository.AddOrUpdatePropertyAsync(property, product.Key);

            await _dataAccess.Received(1).SelectByKeyAsync<ProductEntity>(product.Key);
            await _dataAccess.Received(1).UpdateAsync(product, product.Key);

            Assert.Equal(product.Properties.Count, 1);
        }

        [Fact]
        public async Task GetProductByKey()
        {
            var repository = new ProductRepository(_dataAccess);
            var key = KeyGenerator.New();
            var product = Builder<ProductEntity>.CreateNew().Build();

            _dataAccess.SelectByKeyAsync<ProductEntity>(key).Returns(product);

            var persistedProduct = await repository.GetProductByKeyAsync(key);

            Assert.Same(product, persistedProduct);
        }

        [Fact]
        public async Task NonExistantProductOnGetByKey()
        {
            var repository = new ProductRepository(_dataAccess);
            var key = KeyGenerator.New();
            var persistedProduct = await repository.GetProductByKeyAsync(key);

            Assert.Null(persistedProduct);
        }

        [Fact]
        public async Task NullableKeyOnGetProduct()
        {
            var repository = new ProductRepository(_dataAccess);
            
            string key = null;

            var persistedProduct = await repository.GetProductByKeyAsync(key);

            Assert.Null(persistedProduct);
        }
    }
}
