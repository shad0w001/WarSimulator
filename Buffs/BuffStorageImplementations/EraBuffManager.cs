using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Buffs.BaseBuffTypes;
using WarSimulator.Nations;
using WarSimulator.Troops.BaseInterfaces;

namespace WarSimulator.Buffs.BuffStorageImplementations
{
    public class EraBuffManager : IEraBuffManager
    {
        public List<IBuff> _buffs { get; set; }
        public EraBuffManager()
        {
            _buffs = new List<IBuff>();
        }

        public void AddBuff(IBuff buff)
        {
            _buffs.Add(buff);
        }

        public void ApplyNationBuffs(INation nation)
        {
            foreach (var buff in _buffs.OfType<INationBuff>())
            {
                buff.ApplyBuff(nation);
            }
        }

        public void ApplyTroopBuffs(IEnumerable<ITroop> army)
        {
            foreach (var buff in _buffs.OfType<ITroopBuff>())
            {
                foreach (var troop in army.Where(troop => troop.GetType() == buff._troopType))
                {
                    buff.ApplyBuff(troop);
                }
            }
        }

        public void RemoveBuff(IBuff buff)
        {
            _buffs?.Remove(buff);
        }

        public void ClearAllBuffs()
        {
            _buffs?.Clear();
        }
    }
}
