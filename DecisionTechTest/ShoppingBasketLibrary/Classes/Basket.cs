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

            return _items.Sum(i => i.Price);
        }
    }
}
