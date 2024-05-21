using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Buffs.BaseBuffTypes;
using WarSimulator.Troops.BaseInterfaces;

namespace WarSimulator.Buffs.BuffImplementations
{
    public class TroopSingleStatPercentageBuff : ITroopBuff
    {
        public int _statsPercentageBuff { get; set; }
        public string _stat {  get; set; }
        public TroopSingleStatPercentageBuff(int statsPercentageBuff, string stat)
        {
            _statsPercentageBuff = statsPercentageBuff;
            _stat = stat;
        }

        public void ApplyBuff(ITroop troop)
        {
            PropertyInfo[] troopProperties = troop.GetType().GetProperties();

            foreach (var property in troopProperties)
            {
                if (property.Name == _stat)
                {
                    double oldValue = (double)property.GetValue(troop);
                    var newValue = (double)(oldValue + oldValue * _statsPercentageBuff / 100);
                    property.SetValue(troop, newValue);
                }
            }
        }
    }
}
