using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Shop.ShoppingCartImp;

namespace WarSimulator.Commands
{
    public class CommandManager
    {
        private static CommandManager _instance;
        private readonly CommandParser _commandParser;

        private CommandManager()
        {
            _commandParser = new CommandParser(new CommandFactory());
        }

        public static CommandManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CommandManager();
            }
            return _instance;
        }

        public void ExecuteGameCommand(string userInput)
        {
            ICommand command = _commandParser.ParseGameCommand(userInput);
            if (command != null)
            {
                command.Execute();
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }
        }

        public void ExecuteShopCommand(string userInput, IShoppingCart cart)
        {
            ICommand command = _commandParser.ParseShopCommand(userInput, cart);
            if (command != null)
            {
                command.Execute();
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }
        }
    }
}
