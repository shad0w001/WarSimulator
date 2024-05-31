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
        public Type _nationType { get; set; }

        public NationGoldPercentageBuff(int goldBuffPercentage, Type type)
        {
            _nationType = type;
             _goldBuffPercentage = goldBuffPercentage;
        }
        public void ApplyBuff(INation nation)
        {
            if(nation.GetType() != _nationType)
            {
                return;
            }
            double increaseAmount = nation.Gold * (_goldBuffPercentage / 100.0);
            nation.Gold = (int)(nation.Gold + increaseAmount);
        }
    }
}
