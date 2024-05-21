using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Bulgaria
{
    public class BulgarianLightInfantry : ILightInfantry
    {
        public double Attack { get; set; }
        public double Defence { get; set; }
        public double Speed { get; set; }
        public double Life { get; set; }
        public double Price { get; set; }
        public BulgarianLightInfantry()
        {
            Attack = 1;
            Defence = 0;
            Speed = 5;
            Life = 20;
            Price = 10;
        }
    }
}
