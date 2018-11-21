using ShoppingBasketLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasketLibrary.Classes
{
    public class HalfPriceBreadOffer : IDiscountOffer
    {
        public decimal GetDiscount(IEnumerable<IProduct> items)
        {
            throw new NotImplementedException();
        }
    }
}
