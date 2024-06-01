using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarSimulator.Commands.Implementations.Game
{
    public class GameExitCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Exiting game...");
            Environment.Exit(0);
        }
    }
}
