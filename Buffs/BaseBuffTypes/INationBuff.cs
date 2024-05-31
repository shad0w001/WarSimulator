using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Nations;

namespace WarSimulator.Buffs.BaseBuffTypes
{
    public interface INationBuff : IBuff
    {
        public Type _nationType { get; set; }
        public void ApplyBuff(INation nation);
    }
}
