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
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Speed { get; set; }
        public int Life { get; set; }
        public int Price { get; set; }
        public int Accuracy { get; set; }
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
