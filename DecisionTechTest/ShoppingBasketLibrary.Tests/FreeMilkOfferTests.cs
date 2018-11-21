using ShoppingBasketLibrary.Classes;
using ShoppingBasketLibrary.Interfaces;
using ShoppingBasketLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ShoppingBasketLibrary.Tests
{
    public class FreeMilkOfferTests
    {
        [Fact]
        public void GetDiscount_throws_null_argument_exception_when_passed_null_object()
        {
            // Arrrange
            var offer = new FreeMilkOffer();

            // Assert
            Assert.Throws<ArgumentNullException>(() => offer.GetDiscount(null));
        }

        [Theory]
        [ClassData(typeof(MilkOfferData))]
        public void GetDiscount_returns_correct_dicscount_amount(int milkCount, decimal expected)
        {
            // Arrange
            var offer = new FreeMilkOffer();
            var items = new List<IProduct>();

            for (int i = 0; i < milkCount; i++)
            {
                items.Add(new Milk());
            }

            // Act
            var result = offer.GetDiscount(items);

            // Assert
            Assert.Equal(expected, result);
        }
    }

    public class MilkOfferData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 0M };
            yield return new object[] { 4, 1.15M };
            yield return new object[] { 8, 2.30M };
            yield return new object[] { 9, 2.30M };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
