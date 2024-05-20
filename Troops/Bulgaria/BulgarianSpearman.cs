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
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Speed { get; set; }
        public int Life { get; set; }
        public int Price { get; set; }
        public int Accuracy { get; set; }
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
