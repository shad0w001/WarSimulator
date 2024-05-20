using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.BaseInterfaces;

namespace WarSimulator.Nations
{
    public class Bulgaria : INation
    {
        public string Name { get; set; }
        public int Gold { get; set; }
        public List<ITroop> Troops { get; set; }

        public Bulgaria()
        {
            Name = "Bulgaria";
            Gold = 10000;
            Troops = new List<ITroop>();
        }
    }
}
