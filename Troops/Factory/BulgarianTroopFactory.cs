using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Nations;
using WarSimulator.Troops.Bulgaria;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Factory
{
    public class BulgarianTroopFactory : ITroopFactory
    {
        public IArcher CreateArcher()
        {
            return new BulgarianArcher();
        }

        public IArmoredInfantry CreateArmoredInfantry()
        {
            return new BulgarianArmoredInfantry();
        }

        public IGunslinger CreateGunslinger()
        {
            return new BulgarianGunslinger();
        }

        public IHeavyCavalry CreateHeavyCavalry()
        {
            return new BulgarianHeavyCavalry();
        }

        public IHeavyInfantry CreateHeavyInfantry()
        {
            return new BulgarianHeavyInfantry();
        }

        public IKnight CreateKnight()
        {
            return new BulgarianKnight();
        }

        public ILightInfantry CreateLightInfantry()
        {
            return new BulgarianLightInfantry();
        }

        public ISpearman CreateSpearman()
        {
            return new BulgarianSpearman();
        }

        public IScout RectruitScout()
        {
            return new BulgarianScout();
        }
    }
}
