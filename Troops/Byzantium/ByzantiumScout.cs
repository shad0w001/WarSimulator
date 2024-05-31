using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.Bulgaria;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Byzantium
{
    public class ByzantiumScout : IScout
    {
        public double Attack { get; set; }
        public double Defence { get; set; }
        public double Speed { get; set; }
        public double Life { get; set; }
        public int Price { get; set; }
        public ByzantiumScout()
        {
            Attack = 7;
            Defence = 3;
            Speed = 15;
            Life = 50;
            Price = 20;
        }
    }
}
