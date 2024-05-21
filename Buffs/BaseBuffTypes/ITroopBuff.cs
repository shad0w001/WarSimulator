using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.BaseInterfaces;

namespace WarSimulator.Buffs.BaseBuffTypes
{
    public interface ITroopBuff : IBuff
    {
        public void ApplyBuff(ITroop troop);
    }
}
