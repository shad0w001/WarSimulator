using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Buffs.BaseBuffTypes;
using WarSimulator.Nations;

namespace WarSimulator.Buffs.BuffImplementations
{
    public class NationGoldPercentageBuff : INationBuff
    {
        private int _goldBuffPercentage {  get; set; }

        public NationGoldPercentageBuff(int goldBuffPercentage)
        {
             _goldBuffPercentage = goldBuffPercentage;
        }
        public void ApplyBuff(INation nation)
        {
            nation.Gold += nation.Gold * (_goldBuffPercentage / 100);
        }
    }
}
