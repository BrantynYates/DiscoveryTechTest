namespace ShoppingBasketLibrary.Interfaces
{
    public interface IBasket
    {
        void AddItem(IProduct item);

        decimal GetTotal();
    }
}
