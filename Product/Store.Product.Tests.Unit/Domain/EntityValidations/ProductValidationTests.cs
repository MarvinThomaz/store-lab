using FizzWare.NBuilder;
using Store.Common.Config;
using Store.Common.Enums;
using Store.Common.Extensions;
using Xunit;
using ProductEntity = Store.Product.Domain.Entities.Product;

namespace Store.Product.Tests.Unit.Domain.EntityValidations
{
    public class ProductValidationTests
    {
        [Fact]
        public void ValidateKeyProduct()
        {
            var product = Builder<ProductEntity>.CreateNew()
                                          .With(p => p.Key, null)
                                          .Build();

            var errors = product.Validate();

            Assert.True(errors.ContainsType(InfoType.RequiredObject));
            Assert.True(errors.Count == 1);
        }

        [Fact]
        public void ValidateKeyMaxLengthProduct()
        {
            var product = Builder<ProductEntity>.CreateNew()
                                          .With(p => p.Key, new string('x', 37))
                                          .Build();

            var errors = product.Validate();

            Assert.True(errors.ContainsType(InfoType.MaxLengthObject));
            Assert.True(errors.Count == 1);
        }

        [Fact]
        public void ValidateKeyMinLengthProduct()
        {
            var product = Builder<ProductEntity>.CreateNew()
                                          .With(p => p.Key, new string('x', 35))
                                          .Build();

            var errors = product.Validate();

            Assert.True(errors.ContainsType(InfoType.MinLengthObject));
            Assert.True(errors.Count == 1);
        }

        [Fact]
        public void ValidateCodeProduct()
        {
            var product = Builder<ProductEntity>.CreateNew()
                                          .With(p => p.Key, KeyGenerator.New())
                                          .With(p => p.Code, null)
                                          .Build();

            var errors = product.Validate();

            Assert.True(errors.ContainsType(InfoType.RequiredObject));
            Assert.True(errors.Count == 1);
        }

        [Fact]
        public void ValidateCodeProductMaxLength()
        {
            var product = Builder<ProductEntity>.CreateNew()
                                        .With(p => p.Key, KeyGenerator.New())
                                        .With(p => p.Code, new string('x', 129))
                                        .Build();

            var errors = product.Validate();

            Assert.True(errors.ContainsType(InfoType.MaxLengthObject));
            Assert.True(errors.Count == 1);
        }

        [Fact]
        public void ValidateNameOfProduct()
        {
            var product = Builder<ProductEntity>.CreateNew()
                                        .With(p => p.Key, KeyGenerator.New())
                                        .With(p => p.Name, null)
                                        .Build();
            
            var errors = product.Validate();

            Assert.True(errors.ContainsType(InfoType.RequiredObject));
            Assert.True(errors.Count == 1);
        }

        [Fact]
        public void ValidateNameProductMaxLength()
        {
            var product = Builder<ProductEntity>.CreateNew()
                                        .With(p => p.Key, KeyGenerator.New())
                                        .With(p => p.Name, new string('x', 51))
                                        .Build();
            
            var errors = product.Validate();

            Assert.True(errors.ContainsType(InfoType.MaxLengthObject));
            Assert.True(errors.Count == 1);
        }

        [Fact]
        public void ValidateNameProductMinLength()
        {
            var product = Builder<ProductEntity>.CreateNew()
                                        .With(p => p.Key, KeyGenerator.New())
                                        .With(p => p.Name, "x")
                                        .Build();

            var errors = product.Validate();

            Assert.True(errors.ContainsType(InfoType.MinLengthObject));
            Assert.True(errors.Count == 1);
        }
    }
}