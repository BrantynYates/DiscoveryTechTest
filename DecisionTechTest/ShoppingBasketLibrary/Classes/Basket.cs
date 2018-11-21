using ShoppingBasketLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketLibrary.Classes
{
    public class Basket : IBasket
    {
        private List<IProduct> _items = new List<IProduct>();

        public int ItemCount { get => _items.Count; }

        public IEnumerable<IProduct> Items => _items;

        public void AddItem(IProduct item)
        {
            if (item == null)
                throw new ArgumentNullException("Item is null");

            _items.Add(item);
        }

        public decimal GetTotal()
        {
            if (_items == null)
                throw new ArgumentNullException("Items list is null");

            // Sum the initial total for discounts to be applied to
            return _items.Sum(i => i.Price);
        }
    }
}
