using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Shop.ShoppingCartImp;

namespace WarSimulator.Commands.Implementations.Cart
{
    public class RemoveItemFromCartCommand : ICommand
    {
        private IShoppingCart _cart;
        private string _name;
        private string _amount;

        public RemoveItemFromCartCommand(IShoppingCart cart, string name, string amount)
        {
            _cart = cart;
            _name = name;
            _amount = amount;
        }
        public void Execute()
        {
            var item = new ShoppingCartItem
            {
                Name = _name,
                Amount = _amount
            };
            _cart.RemoveItemsFromCart(_name);
        }
    }
}
