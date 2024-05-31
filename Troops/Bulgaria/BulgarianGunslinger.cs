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
        public double Attack { get; set; }
        public double Defence { get; set; }
        public double Speed { get; set; }
        public double Life { get; set; }
        public int Price { get; set; }
        public double Accuracy { get; set; }
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
