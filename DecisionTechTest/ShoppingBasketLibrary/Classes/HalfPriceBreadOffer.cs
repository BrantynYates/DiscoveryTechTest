using ShoppingBasketLibrary.Interfaces;
using ShoppingBasketLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketLibrary.Classes
{
    public class HalfPriceBreadOffer : IDiscountOffer
    {
        private readonly int _discountAppliedAtCount = 2;
        private readonly decimal _discountPercentage = .5M;

        public decimal GetDiscount(IEnumerable<IProduct> items)
        {
            // Get butter items to calculate discount
            var butter = items.Where(i => i.GetType() == typeof(Butter));
            if (!butter.Any())
                return 0M;
            
            // Get any bread items to calculate discount
            var bread = items.Where(i => i.GetType() == typeof(Bread));
            if (!bread.Any())
                return 0M;
    
            // Get max number of discounts to apply
            var discountsAvailable = butter.Count() / _discountAppliedAtCount;

            // Make sure we don't apply too many discounts
            var discountableBread = discountsAvailable > bread.Count()
                ? bread.Count()
                : discountsAvailable;

            return discountableBread * (bread.First().Price * _discountPercentage);
        }
    }
}
