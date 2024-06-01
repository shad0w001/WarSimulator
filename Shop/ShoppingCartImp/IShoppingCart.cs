using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarSimulator.Shop.ShoppingCartImp
{
    public interface IShoppingCart
    {
        public List<IShoppingCartItem> Items { get; set; }
        public void AddItemsToCart(IShoppingCartItem item);
        public void RemoveItemsFromCart(string name);
        public void ClearCart();
    }
}
