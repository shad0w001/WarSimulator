using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Commands.Implementations.Cart;
using WarSimulator.Commands.Implementations.Game;
using WarSimulator.Shop.ShoppingCartImp;

namespace WarSimulator.Commands
{
    public class CommandFactory
    {
        private readonly Dictionary<string, Func<ICommand>> _gameCommands;
        private readonly Dictionary<string, Func<IShoppingCart, string[], ICommand>> _cartCommands;

        public CommandFactory()
        {
            _gameCommands = new Dictionary<string, Func<ICommand>>
            {
                { "/game start", () => new GameStartCommand() },
                { "/exit", () => new GameExitCommand() },
            };

            _cartCommands = new Dictionary<string, Func<IShoppingCart, string[], ICommand>>
            {
                { "/cart buy", (cart, args) => new AddItemToCartCommand(cart, args[2], args[3]) },
                { "/cart remove", (cart, args) => new RemoveItemFromCartCommand(cart, args[2], args[3]) },
                { "/cart clear", (cart, args) => new ClearCartCommand(cart) },
                { "/cart confirm", (cart, args) => new ConfirmCartCommand(cart) },
            };
        }

        public ICommand GetCommand(string input, IShoppingCart cart)
        {
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
            {
                Console.WriteLine("Invalid command.");
                return null;
            }

            string commandKey = $"{parts[0]} {parts[1]}";

            if (cart == null)
            {
                if (_gameCommands.TryGetValue(commandKey, out var gameCommandCreator))
                {
                    return gameCommandCreator();
                }
            }
            else
            {
                if (_cartCommands.TryGetValue(commandKey, out var cartCommandCreator))
                {
                    return cartCommandCreator(cart, parts);
                }
            }

            Console.WriteLine("Invalid command.");
            return null;
        }
    }
}
