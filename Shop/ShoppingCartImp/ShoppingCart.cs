using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            var alreadyExistingItem = Items.Where(x => x.Name.ToLower() == item.Name.ToLower()).FirstOrDefault();

            if(alreadyExistingItem is not null)
            {
                alreadyExistingItem.Amount = (int.Parse(alreadyExistingItem.Amount) + int.Parse(item.Amount)).ToString();
                return;
            }

            Items.Add(item);
        }

        public void ClearCart()
        {
            Items.Clear();
        }

        public void RemoveItemsFromCart(IShoppingCartItem item)
        {
            var alreadyExistingItem = Items.Where(x => x.Name.ToLower() == item.Name.ToLower()).FirstOrDefault();

            if(alreadyExistingItem is null)
            {
                return;
            }

            if (alreadyExistingItem is not null &&
                int.Parse(alreadyExistingItem.Amount) > int.Parse(item.Amount))
            {
                alreadyExistingItem.Amount = (int.Parse(alreadyExistingItem.Amount) - int.Parse(item.Amount)).ToString();
                return;
            }

            Items.Remove(Items.Where(x => x.Name.ToLower() == item.Name.ToLower()).FirstOrDefault());
        }
        public void RemoveLastItemFromCart()
        {
            Items.Remove(Items.LastOrDefault());
        }
    }
}
