using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Nations;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.Bulgaria;
using WarSimulator.Troops.TroopTypes;
using WarSimulator.Troops.Factory.FactoryUnitImp;

namespace WarSimulator.Troops.Factory
{
    public class BulgarianTroopFactory : ITroopFactory
    {
        public List<IFactoryUnit> _factoryUnits { get; set; }

        public BulgarianTroopFactory()
        {
            _factoryUnits =
            [
                new FactoryUnit("Archer", () => new BulgarianArcher(), true),
                new FactoryUnit("ArmoredInfantry", () => new BulgarianArmoredInfantry(), true),
                new FactoryUnit("Gunslinger", () => new BulgarianGunslinger(), true),
                new FactoryUnit("HeavyCavalry", () => new BulgarianHeavyCavalry(), true),
                new FactoryUnit("HeavyInfantry", () => new BulgarianHeavyInfantry(), true),
                new FactoryUnit("Knight", () => new BulgarianKnight(), true),
                new FactoryUnit("LightInfantry", () => new BulgarianLightInfantry(), true),
                new FactoryUnit("Scout", () => new BulgarianScout(), true),
                new FactoryUnit("Spearman", () => new BulgarianSpearman(), true),
            ];
        }

        public ITroop CreateTroop(string name)
        {
            var unit = _factoryUnits.FirstOrDefault(x => x.Name == name);

            if (unit is null)
            {
                Console.WriteLine("Creation: Troop not found");
                return null;
            }

            if (!unit.IsUnlocked)
            {
                Console.WriteLine("Creation: Troop is locked");
                return null;
            }

            return unit.CreateInstance();
        }

        public void UnlockTroop(string name)
        {
            var unit = _factoryUnits.FirstOrDefault(x => x.Name == name);
            if (unit is null)
            {
                Console.WriteLine("Unlock: Troop not found");
                return;
            }

            if (unit.IsUnlocked)
            {
                Console.WriteLine("Unlock: Troop is already unlocked");
                return;
            }

            unit.IsUnlocked = true;
        }
    }
}
