using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Bulgaria
{
    public class BulgarianHeavyCavalry : IHeavyCavalry
    {
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Speed { get; set; }
        public int Life { get; set; }
        public int Price { get; set; }
        public BulgarianHeavyCavalry()
        {
            Attack = 15;
            Defence = 15;
            Speed = 1;
            Life = 150;
            Price = 100;
        }
    }
}
