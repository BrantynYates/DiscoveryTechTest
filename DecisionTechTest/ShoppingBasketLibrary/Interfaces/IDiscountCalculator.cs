using System.Collections.Generic;

namespace ShoppingBasketLibrary.Interfaces
{
    public interface IDiscountCalculator
    {
        decimal CalculateDiscount(IEnumerable<IProduct> items);
    }
}
