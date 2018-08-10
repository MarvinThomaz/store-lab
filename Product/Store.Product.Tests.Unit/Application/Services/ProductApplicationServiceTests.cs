﻿using FizzWare.NBuilder;
using NSubstitute;
using Store.Common.Config;
using Store.Product.Application.Services;
using Store.Product.Domain.Entities;
using Store.Product.Domain.Repositories;
using System.Threading.Tasks;
using Xunit;
using ProductEntity = Store.Product.Domain.Entities.Product;

namespace Store.Product.Tests.Unit.Application.Services
{

    public class ProductApplicationServiceTests
    {
        private readonly IProductRepository _repository = Substitute.For<IProductRepository>();

        [Fact]
        public async Task CreateProductWithProperties()
        {
            var service = new ProductApplicationService(_repository);
            var properties = Builder<ProductProperty>.CreateListOfSize(2).Build();
            var product = Builder<ProductEntity>.CreateNew()
                                        .With(p => p.Key, KeyGenerator.New())
                                        .With(p => p.Properties, properties).Build();

            await service.RegisterNewProductAsync(product);

            await _repository.Received(1).CreateProductAsync(product);
        }

        [Fact]
        public async Task CreateProduct()
        {
            var service = new ProductApplicationService(_repository);
            var product = Builder<ProductEntity>.CreateNew().With(p => p.Key, KeyGenerator.New()).Build();

            await service.RegisterNewProductAsync(product);

            await _repository.Received(1).CreateProductAsync(product);
        }

        [Fact]
        public async Task GetProductByKey()
        {
            var service = new ProductApplicationService(_repository);
            var key = KeyGenerator.New();
            var product = Builder<ProductEntity>.CreateNew().Build();

            _repository.GetProductByKeyAsync(key).Returns(product);

            var persistedProduct = await service.GetProductByKeyAsync(key);

            Assert.Same(product, persistedProduct);
        }

        [Fact]
        public async Task NonExistantProductOnGetByKey()
        {
            var service = new ProductApplicationService(_repository);
            var key = KeyGenerator.New();
            var persistedProduct = await service.GetProductByKeyAsync(key);

            Assert.Null(persistedProduct);
        }

        [Fact]
        public async Task NullableKeyOnGetProduct()
        {
            var service = new ProductApplicationService(_repository);

            string key = null;

            var persistedProduct = await service.GetProductByKeyAsync(key);

            Assert.Null(persistedProduct);
        }
    }
}
