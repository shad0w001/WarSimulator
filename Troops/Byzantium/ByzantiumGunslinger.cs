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
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Speed { get; set; }
        public int Life { get; set; }
        public int Price { get; set; }
        public int Accuracy { get; set; }
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
