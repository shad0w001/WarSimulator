using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Shop.ShoppingCartImp;

namespace WarSimulator.Commands.Implementations.Cart
{
    public class ConfirmCartCommand : ICommand
    {
        private IShoppingCart _cart;
        public ConfirmCartCommand(IShoppingCart cart)
        {
            _cart = cart;
        }
        public void Execute()
        {
            _cart.IsShopping = false;
            Console.WriteLine($"Purchases confirmed, moving on.");
            Console.Clear();
        }
    }
}
