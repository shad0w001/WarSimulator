using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Bulgaria
{
    public class BulgarianSpearman : ISpearman
    {
        public double Attack { get; set; }
        public double Defence { get; set; }
        public double Speed { get; set; }
        public double Life { get; set; }
        public int Price { get; set; }
        public double Accuracy { get; set; }
        public BulgarianSpearman()
        {
            Attack = 10;
            Defence = 1;
            Speed = 2;
            Life = 15;
            Accuracy = 60;
            Price = 15;
        }
    }
}
