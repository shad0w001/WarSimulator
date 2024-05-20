using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.Byzantium;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Bulgaria
{
    public class BulgarianHeavyInfantry : IHeavyInfantry
    {
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Speed { get; set; }
        public int Life { get; set; }
        public int Price { get; set; }
        public BulgarianHeavyInfantry()
        {
            Attack = 8;
            Defence = 5;
            Speed = 2;
            Life = 80;
            Price = 30;
        }
    }
}
