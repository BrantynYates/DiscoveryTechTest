﻿using ShoppingBasketLibrary.Interfaces;

namespace ShoppingBasketLibrary.Models
{
    public class Product : IProduct
    {
        public decimal Price => 1M;
    }
}
