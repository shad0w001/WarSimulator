using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Shop.ShoppingCartImp;

namespace WarSimulator.Commands
{
    public class CommandParser
    {
        private readonly CommandFactory _commandFactory;

        public CommandParser(CommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public ICommand ParseGameCommand(string userInput)
        {
            return _commandFactory.GetCommand(userInput, null);
        }

        public ICommand ParseShopCommand(string userInput, IShoppingCart cart)
        {
            return _commandFactory.GetCommand(userInput, cart);
        }
    }
}
