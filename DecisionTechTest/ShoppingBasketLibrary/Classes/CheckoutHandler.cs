using ShoppingBasketLibrary.Interfaces;
using System;

namespace ShoppingBasketLibrary.Classes
{
    public class CheckoutHandler : ICheckoutHandler
    {
        private IDiscountCalculator _calc;

        public CheckoutHandler(IDiscountCalculator calc)
        {
            _calc = calc;
        }

        public decimal CalculateBasketTotal(IBasket basket)
        {
            if (basket == null)
                throw new ArgumentNullException("Basket is null");

            if (_calc == null)
                throw new ArgumentNullException("Calculator is null");

            // Get baskets total
            var total = basket.GetTotal();

            // Apply discounts
            var discount = _calc.CalculateDiscount(basket.Items);

            return total - discount;
        }
    }
}
