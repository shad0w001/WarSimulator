using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Byzantium
{
    public class ByzantiumArcher : IArcher
    {
        public double Attack { get; set; }
        public double Defence { get; set; }
        public double Speed { get; set; }
        public double Life { get; set; }
        public int Price { get; set; }
        public double Accuracy { get; set; }
        public ByzantiumArcher()
        {
            Attack = 10;
            Defence = 2;
            Speed = 7;
            Life = 20;
            Accuracy = 75;
            Price = 20;
        }
    }
}
