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
            var basket = new Basket();

            // Assert
            Assert.Throws<ArgumentNullException>(() => basket.AddItem(null));
        }

        [Fact]
        public void AddItem_succeeds()
        {
            // Arrange
            var basket = new Basket();
            var item = new Product();

            // Act
            basket.AddItem(item);
            var result = basket.ItemCount;

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void GetTotal_returns_zero()
        {
            // Arrange
            var basket = new Basket();

            // Act
            var result = basket.GetTotal();

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void GetTotal_returns_correct_total_for_one_item()
        {
            // Arrange
            var basket = new Basket();
            var item = new Product();

            basket.AddItem(item);

            // Act
            var result = basket.GetTotal();

            // Assert
            Assert.Equal(1, result);
        }
    }
}
