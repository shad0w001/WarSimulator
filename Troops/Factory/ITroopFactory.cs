using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Nations;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Factory
{
    public interface ITroopFactory
    {
        public ILightInfantry CreateLightInfantry();
        public IArmoredInfantry CreateArmoredInfantry();
        public IHeavyInfantry CreateHeavyInfantry();
        public IScout RectruitScout();
        public IKnight CreateKnight();
        public IHeavyCavalry CreateHeavyCavalry();
        public ISpearman CreateSpearman();
        public IArcher CreateArcher();
        public IGunslinger CreateGunslinger();
    }
}
