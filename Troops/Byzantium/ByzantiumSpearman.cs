using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.Bulgaria;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Byzantium
{
    public class ByzantiumSpearman : ISpearman
    {
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Speed { get; set; }
        public int Life { get; set; }
        public int Price { get; set; }
        public int Accuracy { get; set; }
        public ByzantiumSpearman()
        {
            Attack = 9;
            Defence = 1;
            Speed = 3;
            Life = 13;
            Accuracy = 65;
            Price = 15;
        }
    }
}
