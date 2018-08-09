using Store.Common.Infra;
using Store.Product.API.V1.Models.Response;
using Store.Product.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Product.API.V1.Mappers
{
    public class LaunchEnumToLaunchTypesMapper : IMapper<LaunchEnum, IEnumerable<LaunchTypesResponse>>
    {
        public IEnumerable<LaunchTypesResponse> Map(LaunchEnum source)
        {
            var values = Enum.GetValues(source.GetType());
            var response = new List<LaunchTypesResponse>();

            foreach (int value in values)
            {
                var name = ((LaunchEnum)value).ToString();
                var launch = new LaunchTypesResponse { Key = value, Type = name };

                response.Add(launch);
            }

            return response;
        }
    }
}
