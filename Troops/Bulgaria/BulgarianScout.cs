using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Bulgaria
{
    public class BulgarianScout : IScout
    {
        public double Attack { get; set; }
        public double Defence { get; set; }
        public double Speed { get; set; }
        public double Life { get; set; }
        public int Price { get; set; }
        public BulgarianScout()
        {
            Attack = 16;
            Defence = 2;
            Speed = 20;
            Life = 50;
            Price = 20;
        }
    }
}
