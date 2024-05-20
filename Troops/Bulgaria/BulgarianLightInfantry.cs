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
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Speed { get; set; }
        public int Life { get; set; }
        public int Price { get; set; }
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
