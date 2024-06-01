using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Buffs.BaseBuffTypes;
using WarSimulator.Buffs.BuffStorageImplementations;
using WarSimulator.Nations;
using WarSimulator.Timespan.Cycles;

namespace WarSimulator.Timespan.Eras
{
    public class Era
    {
        private IEraBuffManager _buffManager {  get; set; }
        private List<Cycle> _cycles {  get; set; }
        private Era()
        {
            _buffManager = new EraBuffManager();
            _cycles = new List<Cycle>();
        }
        public static Era SetupEra()
        {
            return new Era();
        }
        public Era AddCycle(Cycle cycle)
        {
            _cycles.Add(cycle);
            return this;
        }
        public Era RemoveCycle(Cycle cycle)
        {
            _cycles.Remove(cycle);
            return this;
        }

        public Era AddBuff(IBuff buff)
        {
            _buffManager.AddBuff(buff);
            return this;
        }
        public Era RemoveBuff(IBuff buff)
        {
            _buffManager.RemoveBuff(buff);
            return this;
        }
        public void ApplyBuffs(List<INation> nations)
        {
            foreach(var n in nations)
            {
                this._buffManager.ApplyNationBuffs(n);
                this._buffManager.ApplyTroopBuffs(n.Army);
            }
            
        }
        public void ClearBuffs()
        {
            this._buffManager.ClearAllBuffs();
        }
    }
}
