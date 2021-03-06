﻿using Store.Common.Builders;
using Store.Product.Domain.Entities;
using Store.Product.Presentation.V1.Mappers.Interfaces;
using Store.Product.Presentation.V1.Models.Request;

namespace Store.Product.Presentation.V1.Mappers.Implementations
{
    public class CreateLaunchRequestToLaunchMapper : ICreateLaunchRequestToLaunchMapper
    {
        private readonly ICreateCoinRequestToCoinMapper _coinMapper;

        public CreateLaunchRequestToLaunchMapper(ICreateCoinRequestToCoinMapper coinMapper)
        {
            _coinMapper = coinMapper;
        }

        public Launch Map(CreateLaunchRequest source)
        {
            if (source == null)
                return null;

            var coin = _coinMapper.Map(source.Coin);

            return new Launch
            {
                Key = KeyBuilder.Build(),
                Type = source.Type,
                Value = source.Value,
                ValueType = source.ValueType,
                IsAvailable = true,
                Coin = coin
            };
        }
    }
}