using Store.Product.Presentation.V1.Mappers.Interfaces;
using Store.Product.Presentation.V1.Models.Request;

namespace Store.Product.Presentation.V1.Mappers.Implementations
{
    public class UpdateProductRequestToProduct : IUpdateProductRequestToProduct
    {
        public Domain.Entities.Product Map(UpdateProductRequest source)
        {
            if (source == null)
                return null;

            return new Domain.Entities.Product
            {
                Name = source.Name
            };
        }
    }
}
