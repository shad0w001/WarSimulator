using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Bulgaria
{
    public class BulgarianArcher : IArcher
    {
        public double Attack { get; set; }
        public double Defence { get; set; }
        public double Speed { get; set; }
        public double Life { get; set; }
        public double Price { get; set; }
        public double Accuracy { get; set; }
        public BulgarianArcher()
        {
            Attack = 12;
            Defence = 2;
            Speed = 5;
            Life = 20;
            Accuracy = 50;
            Price = 20;
        }
    }
}
