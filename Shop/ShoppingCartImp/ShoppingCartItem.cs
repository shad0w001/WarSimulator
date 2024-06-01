using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarSimulator.Shop.ShoppingCartImp
{
    public class ShoppingCartItem : IShoppingCartItem
    {
        public string Name { get; set; }
        public string Amount { get; set; }
    }
}
