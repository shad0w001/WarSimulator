using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarSimulator.Shop.ShoppingCartImp
{
    public interface IShoppingCartItem
    {
        public string Name { get; set; }
        public string Amount { get; set; }
    }
}
