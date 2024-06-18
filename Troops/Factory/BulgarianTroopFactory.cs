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
                FactoryUnit.CreateUnit("Archer", () => new BulgarianArcher(), true),
                FactoryUnit.CreateUnit("ArmoredInfantry", () => new BulgarianArmoredInfantry(), true),
                FactoryUnit.CreateUnit("Gunslinger", () => new BulgarianGunslinger(), true),
                FactoryUnit.CreateUnit("HeavyCavalry", () => new BulgarianHeavyCavalry(), true),
                FactoryUnit.CreateUnit("HeavyInfantry", () => new BulgarianHeavyInfantry(), true),
                FactoryUnit.CreateUnit("Knight", () => new BulgarianKnight(), true),
                FactoryUnit.CreateUnit("LightInfantry", () => new BulgarianLightInfantry(), true),
                FactoryUnit.CreateUnit("Scout", () => new BulgarianScout(), true),
                FactoryUnit.CreateUnit("Spearman", () => new BulgarianSpearman(), true),
            ];
        }

        public ITroop CreateTroop(string name)
        {
            var unit = _factoryUnits.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

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

        public List<ITroop> CreateMultipleTroops(string name, int count)
        {
            var troops = new List<ITroop>();
            var unit = _factoryUnits.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

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

            for (int i = 0;  i < count; i++)
            {
                troops.Add(unit.CreateInstance());
            }

            return troops;
        }

        public void UnlockTroop(string name)
        {
            var unit = _factoryUnits.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
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
