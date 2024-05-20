using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Bulgaria
{
    public class BulgarianGunslinger : IGunslinger
    {
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Speed { get; set; }
        public int Life { get; set; }
        public int Price { get; set; }
        public int Accuracy { get; set; }
        public BulgarianGunslinger()
        {
            Attack = 20;
            Defence = 3;
            Speed = 2;
            Life = 25;
            Accuracy = 90;
            Price = 35;
        }
    }
}
