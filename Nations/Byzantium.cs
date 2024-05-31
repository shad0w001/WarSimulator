using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.Factory;

namespace WarSimulator.Nations
{
    public class Byzantium : INation
    {
        public string Name { get; set; }
        public int Gold { get; set; }
        public List<ITroop> Army { get; set; }
        public ITroopFactory _rectruitmentCenter { get; set; }

        public Byzantium()
        {
            Name = "Byzantium";
            Gold = 10000;
            Army = new List<ITroop>();
            _rectruitmentCenter = new ByzantiumTroopFactory();
        }
    }
}
