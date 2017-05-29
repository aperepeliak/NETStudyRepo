using System.Collections.Generic;

namespace ShoppingCart
{
    public class Cart
    {
        public List<CartItem> Items { get; }

        public Cart()
        {
            Items = new List<CartItem>();
        }

        public void AddItem(CartItem item)
        {
            if (Items.Contains(item)) return;

            Items.Add(item);
        }

        public void RemoveItem(CartItem cartItem)
        {
            Items.Remove(cartItem);
        }

        public decimal GetCartTotal()
        {
            decimal total = 0m;
            foreach (var item in Items)
            {
                total += item.GetItemPrice();
            }
            return total;
        }
    }
}
