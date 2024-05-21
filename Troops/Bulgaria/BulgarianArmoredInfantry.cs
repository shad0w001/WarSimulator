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
        public double Attack { get; set; }
        public double Defence { get; set; }
        public double Speed { get; set; }
        public double Life { get; set; }
        public double Price { get; set; }
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
