using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarSimulator.Shop.ShoppingCartImp
{
    public class ShoppingCart : IShoppingCart
    {
        public bool IsShopping { get; set; }
        public List<IShoppingCartItem> Items { get; set; }
        public ShoppingCart()
        {
            IsShopping = true;
            Items = new List<IShoppingCartItem>();
        }

        public void AddItemsToCart(IShoppingCartItem item)
        {
            Items.Add(item);
        }

        public void ClearCart()
        {
            Items.Clear();
        }

        public void RemoveItemsFromCart(string name)
        {
            Items.Remove(Items.Where(item => item.Name == name).FirstOrDefault());
        }
    }
}
