using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Buffs.BuffStorageImplementations;
using WarSimulator.Timespan.Cycles;

namespace WarSimulator.Timespan.Eras
{
    public class Era
    {
        private EraBuffManager _buffManager {  get; set; }
        private List<Cycle> _cycles {  get; set; }
        public void Proceed()
        {

        }
    }
}
