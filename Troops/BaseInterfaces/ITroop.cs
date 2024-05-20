using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarSimulator.Troops.BaseInterfaces
{
    public interface ITroop
    {
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Speed { get; set; }
        public int Life { get; set; }
        public int Price { get; set; }
    }
}
