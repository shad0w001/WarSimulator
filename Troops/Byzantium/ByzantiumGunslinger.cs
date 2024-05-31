using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Byzantium
{
    public class ByzantiumGunslinger : IGunslinger
    {
        public double Attack { get; set; }
        public double Defence { get; set; }
        public double Speed { get; set; }
        public double Life { get; set; }
        public int Price { get; set; }
        public double Accuracy { get; set; }
        public ByzantiumGunslinger()
        {
            Attack = 25;
            Defence = 4;
            Speed = 1;
            Life = 25;
            Accuracy = 65;
            Price = 35;
        }
    }
}
