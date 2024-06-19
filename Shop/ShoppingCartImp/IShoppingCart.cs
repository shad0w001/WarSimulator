using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarSimulator.Shop.ShoppingCartImp
{
    public interface IShoppingCart
    {
        public bool IsShopping { get; set; }
        public List<IShoppingCartItem> Items { get; set; }
        public void AddItemsToCart(IShoppingCartItem item);
        public void RemoveItemsFromCart(IShoppingCartItem item);
        public void RemoveLastItemFromCart();
        public void ClearCart();
    }
}
