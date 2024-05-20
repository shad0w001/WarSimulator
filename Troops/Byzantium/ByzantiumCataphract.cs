using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Byzantium
{
    public class ByzantiumCataphract : ICataphract
    {
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Speed { get; set; }
        public int Life { get; set; }
        public int Price { get; set; }
        public ByzantiumCataphract()
        {
            Attack = 30;
            Defence = 30;
            Speed = 0;
            Life = 250;
            Price = 300;
        }
    }
}
