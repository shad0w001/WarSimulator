﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.Bulgaria;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Byzantium
{
    public class ByzantiumHeavyInfantry : IHeavyInfantry
    {
        public double Attack { get; set; }
        public double Defence { get; set; }
        public double Speed { get; set; }
        public double Life { get; set; }
        public int Price { get; set; }
        public ByzantiumHeavyInfantry()
        {
            Attack = 8;
            Defence = 7;
            Speed = 1;
            Life = 80;
            Price = 30;
        }
    }
}
