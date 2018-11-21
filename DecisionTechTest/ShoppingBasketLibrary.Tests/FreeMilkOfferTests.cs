using ShoppingBasketLibrary.Classes;
using ShoppingBasketLibrary.Interfaces;
using ShoppingBasketLibrary.Models;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ShoppingBasketLibrary.Tests
{
    public class FreeMilkOfferTests
    {
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
        yield return new object[] { 1, 1.15M };
        yield return new object[] { 4, 3.45M };
        yield return new object[] { 8, 6.90M };
        yield return new object[] { 9, 8.05M };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
}
