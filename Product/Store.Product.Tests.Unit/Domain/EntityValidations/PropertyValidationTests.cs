using FizzWare.NBuilder;
using Store.Common.Enums;
using Store.Common.Extensions;
using Store.Product.Domain.Entities;
using Xunit;

namespace Store.Product.Tests.Unit.Domain.EntityValidations
{
    public class PropertyValidationTests
    {
        [Fact]
        public void ValidatePropertysName()
        {
            var property = Builder<Property>.CreateNew()
                                              .With(p => p.Name, null)
                                              .Build();

            var errors = property.ValidateEntity();

            Assert.True(errors.ContainsType(InfoType.RequiredObject));
            Assert.True(errors.Count == 1);
        }

        [Fact]
        public void ValidatePropertiesNameMaxLengthProduct()
        {
            var properties = Builder<Property>.CreateNew()
                                              .With(p => p.Name, new string('x', 51))
                                              .Build();

            var errors = properties.ValidateEntity();

            Assert.True(errors.ContainsType(InfoType.MaxLengthObject));
            Assert.True(errors.Count == 1);
        }

        [Fact]
        public void ValidatePropertiesNameMinLengthProduct()
        {
            var properties = Builder<Property>.CreateNew()
                                              .With(p => p.Name, "x")
                                              .Build();

            var errors = properties.ValidateEntity();

            Assert.True(errors.ContainsType(InfoType.MinLengthObject));
            Assert.True(errors.Count == 1);
        }

        [Fact]
        public void ValidatePropertiesValueMaxLengthProduct()
        {
            var properties = Builder<Property>.CreateNew()
                                              .With(p => p.Value, new string('x', 257))
                                              .Build();

            var errors = properties.ValidateEntity();

            Assert.True(errors.ContainsType(InfoType.MaxLengthObject));
            Assert.True(errors.Count == 1);
        }
    }
}