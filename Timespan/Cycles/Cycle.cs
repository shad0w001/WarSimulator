using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Buffs.BaseBuffTypes;
using WarSimulator.Buffs.BuffStorageImplementations;
using WarSimulator.Nations;

namespace WarSimulator.Timespan.Cycles
{
    public class Cycle
    {
        private ICycleBuffManager _buffManager {  get; set; }
        private Cycle()
        {
            _buffManager = new CycleBuffManager();
        }
        public static Cycle CreateCycle()
        {
            return new Cycle();
        }
        public Cycle AddBuff(IBuff buff)
        {
            _buffManager.AddBuff(buff);
            return this;
        }
        public Cycle RemoveBuff(IBuff buff)
        {
            _buffManager.RemoveBuff(buff);
            return this;
        }
        public Cycle ApplyBuffs(List<INation> nations)
        {
            foreach (var n in nations)
            {
                this._buffManager.ApplyNationBuffs(n);
                this._buffManager.ApplyTroopBuffs(n.Army);
            }
            return this;

        }
        public Cycle ClearBuffs()
        {
            _buffManager.ClearAllBuffs();
            return this;
        } 
    }
}
