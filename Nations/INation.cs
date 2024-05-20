using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.BaseInterfaces;

namespace WarSimulator.Nations
{
    public interface INation
    {
        public string Name { get; set; }
        public int Gold { get; set; }
        public List<ITroop> Army { get; set; }
    }
}
