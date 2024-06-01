using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Nations;
using WarSimulator.Troops.BaseInterfaces;

namespace WarSimulator.Battles
{
    public interface IBattleManager
    {
        public void ExecuteBattleCycle(INation nationOne, INation nationTwo);
    }
}
