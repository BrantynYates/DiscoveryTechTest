using ShoppingBasketLibrary.Interfaces;
using System;
using System.Collections.Generic;

namespace ShoppingBasketLibrary.Classes
{
    public class DiscountCalculator : IDiscountCalculator
    {
        private IEnumerable<IDiscountOffer> _offers;

        public DiscountCalculator(IEnumerable<IDiscountOffer> offers)
        {
            _offers = offers;
        }

        public decimal CalculateDiscount(IEnumerable<IProduct> items)
        {
            if (items == null)
                throw new ArgumentNullException("Item list is null");

            if (_offers == null)
                throw new ArgumentNullException("Offers list is null");

            return 0;
        }
    }
}
