﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Nations;
using WarSimulator.Troops.BaseInterfaces;

namespace WarSimulator.Buffs.BaseBuffTypes
{
    public interface IBuffStorage
    {
        public List<IBuff> _buffs { get; set; }
        public void AddBuff(IBuff buff);
        public void RemoveBuff(IBuff buff);
        public void ApplyNationBuffs(IEnumerable<INation> nations);
        public void ApplyTroopBuffs(IEnumerable<ITroop> army);
    }
}
