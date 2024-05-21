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
        public double Attack { get; set; }
        public double Defence { get; set; }
        public double Speed { get; set; }
        public double Life { get; set; }
        public double Price { get; set; }
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
