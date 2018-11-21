namespace ShoppingBasketLibrary.Interfaces
{
    public interface ICheckoutHandler
    {
        decimal CalculateBasketTotal(IBasket basket);
    }
}
