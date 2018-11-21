using System.Collections.Generic;

namespace ShoppingBasketLibrary.Interfaces
{
    public interface IBasket
    {
        IEnumerable<IProduct> Items { get; }

        void AddItem(IProduct item);

        decimal GetTotal();
    }
}
