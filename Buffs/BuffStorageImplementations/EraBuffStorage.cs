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
    public class EraBuffStorage : IEraBuffManager
    {
        public List<IBuff> _buffs { get; set; }
        public EraBuffStorage()
        {
            _buffs = new List<IBuff>();
        }

        public void AddBuff(IBuff buff)
        {
            _buffs.Add(buff);
        }

        public void ApplyNationBuffs(IEnumerable<INation> nations)
        {
            foreach (var nation in nations)
            {
                foreach (var buff in _buffs)
                {
                    if (buff is INationBuff)
                    {
                        ((INationBuff)buff).ApplyBuff(nation);
                    }
                }
            }
        }

        public void ApplyTroopBuffs(IEnumerable<ITroop> army)
        {
            foreach (var troop in army)
            {
                foreach (var buff in _buffs)
                {
                    if (buff is ITroopBuff)
                    {
                        (buff as ITroopBuff).ApplyBuff(troop);
                    }
                }
            }
        }

        public void RemoveBuff(IBuff buff)
        {
            _buffs?.Remove(buff);
        }
    }
}
