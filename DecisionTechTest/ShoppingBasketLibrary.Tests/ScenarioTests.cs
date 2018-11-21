using ShoppingBasketLibrary.Classes;
using ShoppingBasketLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppingBasketLibrary.Tests
{
    public class ScenarioTests
    {
        /// <summary>
        /// Scenario one:
        /// 1 bread, 1 milk and 1 butter are added to cart. No discount is applied.
        /// </summary>
        [Fact]
        public void GetTotal_returns_correct_price_where_no_discount_is_added()
        {
            // Arrange
            var basket = new Basket();

            basket.AddItem(new Bread());
            basket.AddItem(new Butter());
            basket.AddItem(new Milk());

            // Act
            var result = basket.GetTotal();

            // Assert
            Assert.Equal(2.95M, result);
        }

        /// <summary>
        /// Scenario two:
        /// 2 butters and 2 breads are added to cart. Discount of 50% is applied to one bread.
        /// </summary>
        [Fact]
        public void GetTotal_returns_correct_discounted_price_for_one_half_price_bread()
        {
            // Arrange
            var basket = new Basket();

            basket.AddItem(new Butter());
            basket.AddItem(new Butter());
            basket.AddItem(new Bread());
            basket.AddItem(new Bread());

            // Act
            var result = basket.GetTotal();

            // Assert
            Assert.Equal(3.10M, result);
        }

        /// <summary>
        /// Scenario three:
        /// 4 milks are added to cart. Discount of 1 milk is applied.
        /// </summary>
        [Fact]
        public void GetTotal_returns_correct_discounted_price_for_one_free_milk()
        {
            // Arrange
            var basket = new Basket();

            for (int i = 0; i < 4; i++)
            {
                basket.AddItem(new Milk());
            }

            // Act
            var result = basket.GetTotal();

            // Assert
            Assert.Equal(3.45M, result);
        }

        /// <summary>
        /// Scenario four:
        /// 2 butters, 1 bread and 8 milks are added to cart. Discount of two milks and and one half price bread is applied.
        /// </summary>
        [Fact]
        public void GetTotal_returns_correct_price_where_multiple_discounts_are_applied()
        {
            // Arrange
            var basket = new Basket();

            basket.AddItem(new Butter());
            basket.AddItem(new Butter());
            basket.AddItem(new Bread());

            for (int i = 0; i < 8; i++)
            {
                basket.AddItem(new Milk());
            }

            // Act
            var result = basket.GetTotal();

            // Assert
            Assert.Equal(9M, result);
        }
    }
}
