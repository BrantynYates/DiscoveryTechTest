using ShoppingBasketLibrary.Models;

namespace ShoppingBasketLibrary.Interfaces
{
    public interface IBasket
    {
        void AddItem(Product item);

        decimal GetTotal();
    }
}
