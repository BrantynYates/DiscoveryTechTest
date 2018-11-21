using ShoppingBasketLibrary.Interfaces;
using System;

namespace ShoppingBasketLibrary.Classes
{
    public class CheckoutHandler : ICheckoutHandler
    {
        private IBasket _basket;
        private IDiscountCalculator _calc;

        public CheckoutHandler(IBasket basket, IDiscountCalculator calc)
        {
            _basket = basket;
            _calc = calc;
        }

        public decimal CalculateBasketTotal()
        {
            if (_basket == null)
                throw new ArgumentNullException("Basket is null");

            if (_calc == null)
                throw new ArgumentNullException("Calculator is null");

            return 0;
        }
    }
}
