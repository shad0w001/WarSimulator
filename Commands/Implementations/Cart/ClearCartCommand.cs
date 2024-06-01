using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WarSimulator.Shop.ShoppingCartImp;

namespace WarSimulator.Commands.Implementations.Cart
{
    public class ClearCartCommand : ICommand
    {
        private IShoppingCart _cart;
        public ClearCartCommand(IShoppingCart cart)
        {
            _cart = new ShoppingCart();
        }
        public void Execute()
        {
            _cart.ClearCart();
            Console.WriteLine($"Cart cleared");
        }
    }
}
