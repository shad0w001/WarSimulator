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
    public class TroopAllStatsPercantageBuff : ITroopBuff
    {
        public int _statsPercentageBuff {  get; set; }
        public TroopAllStatsPercantageBuff(int statsPercentageBuff)
        {
            _statsPercentageBuff = statsPercentageBuff;
        }

        public void ApplyBuff(ITroop troop)
        {
            var troopType = troop.GetType();
            var troopProperties = troopType.GetProperties();
            foreach (PropertyInfo property in troopProperties)
            {
                if (property.PropertyType == typeof(double))
                {
                    var oldValue = (double)property.GetValue(troop);
                    var newValue = (double)(oldValue + oldValue * _statsPercentageBuff / 100);
                    property.SetValue(troop, newValue);
                }
            }
        }
    }
}
