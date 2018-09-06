using Store.Product.Domain.Enums;
using Store.Product.Presentation.V1.Models.Request;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Product.API.V1.ModelExamples
{
    public class CreateProductRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {
            const string photoBase64 = "iVBORw0KGgoAAAANSUhEUgAAABkAAAAZCAYAAADE6YVjAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAyZpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuNi1jMDY3IDc5LjE1Nzc0NywgMjAxNS8wMy8zMC0yMzo0MDo0MiAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENDIDIwMTUgKFdpbmRvd3MpIiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOkMzNkEyN0U1RDAxNTExRTU4NEE0QzE0QjYwRkJERDg0IiB4bXBNTTpEb2N1bWVudElEPSJ4bXAuZGlkOkMzNkEyN0U2RDAxNTExRTU4NEE0QzE0QjYwRkJERDg0Ij4gPHhtcE1NOkRlcml2ZWRGcm9tIHN0UmVmOmluc3RhbmNlSUQ9InhtcC5paWQ6QzM2QTI3RTNEMDE1MTFFNTg0QTRDMTRCNjBGQkREODQiIHN0UmVmOmRvY3VtZW50SUQ9InhtcC5kaWQ6QzM2QTI3RTREMDE1MTFFNTg0QTRDMTRCNjBGQkREODQiLz4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz7LLnpTAAADHElEQVR42qSWS0hUURiA/3vua67alNFCdBEKpW1KaBEY0abWroKiVet2BkH7FoJBQhBRmoSEKRWpZYiZjs/SUfHdWDoaOo6jo+M87p37Oqd7JhSZcWZ05ofL5Z77/+f7X+fBwCEi2U+dFsqu3GSKL16FwnPlJL+gmEj2MyYn2HQTA4cQsFhXGTnoR8HNv+D5M0lWpgdN12hPZMu7SuLmYw5+cIhh7DfuVmkVt+6rJwuKTQYBMU0AbD2EmpKYwf4k1n9ArPWyoNYPW2TbKzrb60MddY9VVY0mQDiWZXPvPHoVqbh9z1DCgEwdjisYccBKeZDv6v0WfPmwUosqMh1n9xRyL12vjFY+qDYiQUDEhEyEIRiIHgWt6EJJTtC7oS7PjtBxtKfAny27bBAaGoFshKbG1A1gis6X76VpH6Ltbm8yJDvAPsiaHcuhAImHwK7v7/80MdlDrGwQv2cJ4iGG1z3PqrJJmOwgtP84bADZcM8lQPDWupsLrLuB5bILw2ppNuwPGJ7FqQSIrmsauzI9AJyQHcSy5z0LTj2440+A0CKZM32fOMBZ1QVx1qqYG2w7uAjQQQXt93ivEPBukgxTRhgWRGVX1WcHPkMyiB4J7fILw+0giJmFYdkJ7gmH6ltzJ4XEUjbypUGwtpRMuoxunMT5tSF+v0Dxisri5JC4NjdBuONFg1kBbP6VVWWqvx3SQQwTY+Zn6wuO549XcFEEbqLzjRaVI2khVNTx7hZpZ3UDs0cDEWttSHJA0Ybb6g514LDBaDgY4Mc6XiPBdrQwRAn4mZ73im9t+ciQGGjg43NJ3o5QL1O3LQLRiJpGX/NTnCyVyYwV6xgVp7reMmJOmraVwOYa6lSWf03AcSG0nTVHc62ohTXqbbLNUGQwYEdTTapjDqVyUl5dmpfmHK2QJBpiRSEujvbLrjEHZAqhOVa7G6tFrEF8behiFXkOUN+7GgOnPu3YdI1jBrbW7TZe0EsrrpnWzYVgHAPSC0Pej5b6UFfjE5xmjrQQ6qLucn63G7LMF5aUCjkn7KIa9OUONj0LfaitShcFlX8CDAAi9G5qGRrpTwAAAABJRU5ErkJggg==";

            var photoBytes = Convert.FromBase64String(photoBase64);

            return new CreateProductRequest
            {
                Code = "A1B2C3",
                Name = "Samsung Galaxy S8",
                ProfilePhoto = new CreatePhotoRequest
                {
                    Data = photoBytes,
                    ContentType = "image/png"
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
                        Value = 20,
                        ValueType = ValueTypeEnum.Percentage
                    },
                    new CreateLaunchRequest
                    {
                        Type = LaunchEnum.Discount,
                        Value = 5,
                        ValueType = ValueTypeEnum.Monetary,
                        Coin = new CreateCoinRequest
                        {
                            Country = "Brazil",
                            Name = "R$",
                            Reference = "BRL"
                        }
                    }
                },
                Photos = new List<CreatePhotoRequest>
                {
                    new CreatePhotoRequest
                    {
                        Data = photoBytes,
                        ContentType = "image/png"
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