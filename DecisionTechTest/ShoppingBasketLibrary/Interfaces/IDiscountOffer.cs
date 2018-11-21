using System.Collections.Generic;

namespace ShoppingBasketLibrary.Interfaces
{
    public interface IDiscountOffer
    {
        decimal GetDiscount(IEnumerable<IProduct> items);
    }
}
