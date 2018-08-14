using Store.Product.Presentation.V1.Models.Request;
using Swashbuckle.AspNetCore.Examples;
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
                ProfilePhoto = Encoding.UTF8.GetBytes("photo"),
                Price = new CreatePriceRequest
                {
                    Coin = new CreateCoinRequest
                    {
                        Country = "Brazil",
                        Name = "R$",
                        Reference = "BRL"
                    },
                    Value = 20
                }
            };
        }
    }
}