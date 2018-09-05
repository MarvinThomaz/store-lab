using Store.Product.Domain.Enums;
using Store.Product.Presentation.V1.Models.Request;
using Swashbuckle.AspNetCore.Examples;
using System.Collections.Generic;
using System.Text;

namespace Store.Product.API.V1.ModelExamples
{
    public class CreateProductRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new CreateProductRequest
            {
                Code = "A1B2C3",
                Name = "Samsung Galaxy S8",
                ProfilePhoto = new CreatePhotoRequest
                {
                    Data = Encoding.UTF8.GetBytes("photo"),
                    Name = "Photo"
                },
                Price = new CreatePriceRequest
                {
                    Coin = new CreateCoinRequest
                    {
                        Country = "Brazil",
                        Name = "R$",
                        Reference = "BRL"
                    },
                    Value = 20
                },
                Launches = new List<CreateLaunchRequest>
                {
                    new CreateLaunchRequest
                    {
                        Type = LaunchEnum.Addition,
                        Value = 20
                    },
                    new CreateLaunchRequest
                    {
                        Type = LaunchEnum.Discount,
                        Value = 5
                    }
                },
                Photos = new List<CreatePhotoRequest>
                {
                    new CreatePhotoRequest
                    {
                        Data = Encoding.UTF8.GetBytes("Test Image"),
                        Name = "Test Image"
                    }
                },
                Properties = new List<CreatePropertyRequest>
                {
                    new CreatePropertyRequest
                    {
                        Name = "RAM",
                        Value = "4GB"
                    },
                    new CreatePropertyRequest
                    {
                        Name = "Memory",
                        Value = "64GB"
                    },
                    new CreatePropertyRequest
                    {
                        Name = "Color",
                        Value = "Black"
                    }
                }
            };
        }
    }
}