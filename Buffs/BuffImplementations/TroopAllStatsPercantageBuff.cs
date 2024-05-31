using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Buffs.BaseBuffTypes;
using WarSimulator.Nations;
using WarSimulator.Troops.BaseInterfaces;

namespace WarSimulator.Buffs.BuffImplementations
{
    public class TroopAllStatsPercantageBuff : ITroopBuff
    {
        public int _statsPercentageBuff { get; set; }
        public Type _troopType { get; set; }

        public TroopAllStatsPercantageBuff(int statsPercentageBuff, Type troopType)
        {
            _statsPercentageBuff = statsPercentageBuff;
            _troopType = troopType;
        }

        public void ApplyBuff(ITroop troop)
        {
            if (troop.GetType() != _troopType)
            {
                return;
            }

            var troopProperties = _troopType.GetProperties();
            foreach (PropertyInfo property in troopProperties)
            {
                if (property.PropertyType == typeof(double))
                {
                    var oldValue = (double)property.GetValue(troop);
                    var newValue = (double)(oldValue + (oldValue * _statsPercentageBuff / 100));
                    property.SetValue(troop, newValue);
                }
            }
        }
    }
}
