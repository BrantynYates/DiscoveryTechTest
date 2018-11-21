using ShoppingBasketLibrary.Interfaces;
using ShoppingBasketLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketLibrary.Classes
{
    public class FreeMilkOffer : IDiscountOffer
    {
        private readonly int _discountAppliedAtCount = 4;

        public decimal GetDiscount(IEnumerable<IProduct> items)
        {
            if (items == null)
                throw new ArgumentNullException("Item list is null");

            // Get milk items to calculate discount
            var milk = items.Where(i => i.GetType() == typeof(Milk));

            if (!milk.Any())
                return 0;

            // Get max number of discounts to apply
            var discountsAvailable = milk.Count() / _discountAppliedAtCount;

            return discountsAvailable * milk.First().Price;
        }
    }
}
