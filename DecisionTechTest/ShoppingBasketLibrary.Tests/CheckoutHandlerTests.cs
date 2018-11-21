using Moq;
using ShoppingBasketLibrary.Classes;
using ShoppingBasketLibrary.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace ShoppingBasketLibrary.Tests
{
    public class CheckoutHandlerTests
    {
        [Fact]
        public void CalculateBasketTotal_throws_null_argument_exception_when_basket_is_null()
        {
            // Arrange
            var mock = new Mock<IDiscountCalculator>();
            var handler = new CheckoutHandler(mock.Object);

            // Assert
            Assert.Throws<ArgumentNullException>(() => handler.CalculateBasketTotal(null));
        }

        [Fact]
        public void CalculateBasketTotal_throws_null_argument_exception_when_calc_is_null()
        {
            // Arrange
            var mock = new Mock<IBasket>();
            var handler = new CheckoutHandler(null);

            // Assert
            Assert.Throws<ArgumentNullException>(() => handler.CalculateBasketTotal(mock.Object));
        }

        [Fact]
        public void CalculateBasketTotal_returns_correct_total_with_discount_applied()
        {
            //Arrange
            var mockBasket = new Mock<IBasket>();
            var mockCalc = new Mock<IDiscountCalculator>();
            var handler = new CheckoutHandler(mockCalc.Object);

            mockBasket.Setup(b => b.GetTotal()).Returns(1);
            mockCalc.Setup(c => c.CalculateDiscount(It.IsAny<IEnumerable<IProduct>>())).Returns(.5M);

            // Act
            var result = handler.CalculateBasketTotal(mockBasket.Object);

            // Assert
            Assert.Equal(.5M, result);
        }
    }
}
