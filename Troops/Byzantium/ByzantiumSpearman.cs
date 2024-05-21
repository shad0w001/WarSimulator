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
        public double Attack { get; set; }
        public double Defence { get; set; }
        public double Speed { get; set; }
        public double Life { get; set; }
        public double Price { get; set; }
        public double Accuracy { get; set; }
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
