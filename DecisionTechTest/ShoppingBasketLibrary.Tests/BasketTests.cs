using ShoppingBasketLibrary.Classes;
using ShoppingBasketLibrary.Models;
using System;
using Xunit;

namespace ShoppingBasketLibrary.Tests
{
    public class BasketTests
    {
        [Fact]
        public void AddItem_throws_exception()
        {
            // Arrrange
            var item = new Product();
            var basket = new Basket();

            // Assert
            Assert.ThrowsAny<Exception>(() => basket.AddItem(item));
        }

        [Fact]
        public void GetTotal_throws_exception()
        {
            // Arrrange
            var basket = new Basket();

            // Assert
            Assert.ThrowsAny<Exception>(() => basket.GetTotal());
        }
    }
}
