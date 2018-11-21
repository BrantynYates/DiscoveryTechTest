using Moq;
using ShoppingBasketLibrary.Classes;
using ShoppingBasketLibrary.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ShoppingBasketLibrary.Tests
{
    public class DiscountCalculatorTests
    {
        [Fact]
        public void CalculateDiscount_throws_null_argument_exception_when_passed_null_object()
        {
            // Arrrange
            var calc = new DiscountCalculator(new List<IDiscountOffer>());

            // Assert
            Assert.Throws<ArgumentNullException>(() => calc.CalculateDiscount(null));
        }

        [Fact]
        public void CalculateDiscount_throws_null_argument_exception_when_offers_list_is_null()
        {
            // Arrrange
            var calc = new DiscountCalculator(null);
            var items = new List<IProduct>();

            // Assert
            Assert.Throws<ArgumentNullException>(() => calc.CalculateDiscount(items));
        }


        [Fact]
        public void CalculateDiscount_returns_correct_discount_of_zero_when_items_list_is_empty()
        {
            // Arrange
            var calc = new DiscountCalculator(new List<IDiscountOffer>());
            var items = new List<IProduct>();

            // Act
            var result = calc.CalculateDiscount(items);

            // Assert
            Assert.Equal(0, result);
        }

        [Theory]
        [ClassData(typeof(DiscountCalculatorData))]
        public void CalculateDiscount_returns_correct_discount(decimal expected)
        {
            // Arrange
            var mockOffers = new Mock<IEnumerable<IDiscountOffer>>();
            var mockItems = new Mock<IEnumerable<IProduct>>();

            var calc = new DiscountCalculator(mockOffers.Object);

            // Act
            var result = calc.CalculateDiscount(mockItems.Object);

            // Assert
            Assert.Equal(expected, result);
        }
    }

    public class DiscountCalculatorData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { .5 };
            yield return new object[] { 1 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
