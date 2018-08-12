using Store.Common.Infra;
using Store.Product.Domain.Enums;
using Store.Product.Presentation.V1.Models.Response;
using System.Collections.Generic;

namespace Store.Product.Presentation.V1.Mappers.Interfaces
{
    public interface ILaunchEnumToLaunchTypesMapper : IMapper<LaunchEnum, IEnumerable<LaunchTypesResponse>> { }
}
