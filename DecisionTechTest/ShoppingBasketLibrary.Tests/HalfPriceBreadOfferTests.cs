using ShoppingBasketLibrary.Classes;
using ShoppingBasketLibrary.Interfaces;
using ShoppingBasketLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ShoppingBasketLibrary.Tests
{
    public class HalfPriceBreadOfferTests
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
        [ClassData(typeof(BreadOfferData))]
        public void GetDiscount_returns_correct_dicscount_amount(int butterCount, int breadCount, decimal expected)
        {
            // Arrange
            var offer = new HalfPriceBreadOffer();
            var items = new List<IProduct>();

            for (int i = 0; i < butterCount; i++)
            {
                items.Add(new Butter());
            }

            for (int i = 0; i < breadCount; i++)
            {
                items.Add(new Bread());
            }

            // Act
            var result = offer.GetDiscount(items);

            // Assert
            Assert.Equal(expected, result);
        }
    }

    public class BreadOfferData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 1, 0M };
            yield return new object[] { 2, 1, .5M };
            yield return new object[] { 4, 1, .5M };
            yield return new object[] { 4, 2, 1M };
            yield return new object[] { 4, 3, 1M };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
