using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.Bulgaria;
using WarSimulator.Troops.Byzantium;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Factory
{
    public class ByzantiumTroopFactory : ITroopFactory
    {
        public IArcher CreateArcher()
        {
            return new ByzantiumArcher();
        }

        public IArmoredInfantry CreateArmoredInfantry()
        {
            return new ByzantiumArmoredInfantry();
        }

        public IGunslinger CreateGunslinger()
        {
            return new ByzantiumGunslinger();
        }

        public IHeavyCavalry CreateHeavyCavalry()
        {
            return new ByzantiumHeavyCavalry();
        }

        public IHeavyInfantry CreateHeavyInfantry()
        {
            return new ByzantiumHeavyInfantry();
        }

        public IKnight CreateKnight()
        {
            return new ByzantiumKnight();
        }

        public ILightInfantry CreateLightInfantry()
        {
            return new ByzantiumLightInfantry();
        }

        public ISpearman CreateSpearman()
        {
            return new ByzantiumSpearman();
        }

        public IScout RectruitScout()
        {
            return new ByzantiumScout();
        }
    }
}
