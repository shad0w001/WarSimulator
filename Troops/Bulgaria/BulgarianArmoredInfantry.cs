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
    public class BulgarianArmoredInfantry : IArmoredInfantry
    {
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Speed { get; set; }
        public int Life { get; set; }
        public int Price { get; set; }
        public BulgarianArmoredInfantry()
        {
            Attack = 6;
            Defence = 3;
            Speed = 4;
            Life = 50;
            Price = 20;
        }
    }
}
