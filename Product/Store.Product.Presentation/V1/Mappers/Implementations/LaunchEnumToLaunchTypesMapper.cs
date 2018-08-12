using Store.Product.Domain.Enums;
using Store.Product.Presentation.V1.Mappers.Interfaces;
using Store.Product.Presentation.V1.Models.Response;
using System;
using System.Collections.Generic;

namespace Store.Product.Presentation.V1.Mappers.Implementations
{
    public class LaunchEnumToLaunchTypesMapper : ILaunchEnumToLaunchTypesMapper
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
