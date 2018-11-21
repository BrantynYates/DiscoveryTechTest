using ShoppingBasketLibrary.Interfaces;
using ShoppingBasketLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketLibrary.Classes
{
    public class Basket : IBasket
    {
        private List<IProduct> _items = new List<IProduct>();

        public int ItemCount { get => _items.Count; }

        public void AddItem(IProduct item)
        {
            if (item == null)
                throw new ArgumentNullException();

            _items.Add(item);
        }

        public decimal GetTotal()
        {
            if (_items == null)
                throw new ArgumentNullException();

            // Sum the initial total for discounts to be applied to
            var total = _items.Sum(i => i.Price);

            var discount = 0M;

            // Get milk items to calculate discount
            var milk = _items.Where(i => i.GetType() == typeof(Milk));

            if (milk.Any())
            {
                var discountsAvailable = milk.Count() / 4;
                discount = discountsAvailable * new Milk().Price;
            }

            return total - discount;
        }
    }
}
