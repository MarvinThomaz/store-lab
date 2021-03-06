﻿using System.ComponentModel.DataAnnotations;

namespace Store.Product.Presentation.V1.Models.Request
{
    public class CreatePriceRequest
    {
        [Required]
        public decimal Value { get; set; }

        [Required]
        public CreateCoinRequest Coin { get; set; }
    }
}