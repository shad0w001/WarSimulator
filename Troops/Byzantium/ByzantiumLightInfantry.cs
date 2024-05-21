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
    public class ByzantiumLightInfantry : ILightInfantry
    {
        public double Attack { get; set; }
        public double Defence { get; set; }
        public double Speed { get; set; }
        public double Life { get; set; }
        public double Price { get; set; }
        public ByzantiumLightInfantry()
        {
            Attack = 1;
            Defence = 1;
            Speed = 6;
            Life = 23;
            Price = 10;
        }
    }
}
