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
    public class ByzantiumHeavyCavalry : IHeavyCavalry
    {
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Speed { get; set; }
        public int Life { get; set; }
        public int Price { get; set; }
        public ByzantiumHeavyCavalry()
        {
            Attack = 20;
            Defence = 25;
            Speed = 1;
            Life = 200;
            Price = 100;
        }
    }
}
