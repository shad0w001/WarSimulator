using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Buffs.BaseBuffTypes;
using WarSimulator.Nations;

namespace WarSimulator.Buffs.BuffImplementations
{
    public class NationGoldFlatAmountBuff : INationBuff
    {
        private int _amount { get; set; }
        public Type _nationType { get; set; }

        public NationGoldFlatAmountBuff(int amount, Type type)
        {
            _nationType = type;
            _amount = amount;
        }

        public void ApplyBuff(INation nation)
        {
            if (nation.GetType() != _nationType)
            {
                return;
            }
            nation.Gold += _amount;
        }
    }
}
