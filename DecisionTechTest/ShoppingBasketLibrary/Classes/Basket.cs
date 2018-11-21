using ShoppingBasketLibrary.Interfaces;
using ShoppingBasketLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketLibrary.Classes
{
    public class Basket : IBasket
    {
        private List<Product> _items = new List<Product>();

        public int ItemCount { get => _items.Count; }

        public void AddItem(Product item)
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
