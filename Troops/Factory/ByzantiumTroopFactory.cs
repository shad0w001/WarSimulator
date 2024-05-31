using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.Bulgaria;
using WarSimulator.Troops.Byzantium;
using WarSimulator.Troops.Factory.FactoryUnitImp;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Factory
{
    public class ByzantiumTroopFactory : ITroopFactory
    {
        public List<IFactoryUnit> _factoryUnits { get; set; }

        public ByzantiumTroopFactory()
        {
            _factoryUnits =
            [
                FactoryUnit.CreateUnit("Archer", () => new ByzantiumArcher(), true),
                FactoryUnit.CreateUnit("ArmoredInfantry", () => new ByzantiumArmoredInfantry(), true),
                FactoryUnit.CreateUnit("Gunslinger", () => new ByzantiumGunslinger(), true),
                FactoryUnit.CreateUnit("HeavyCavalry", () => new ByzantiumHeavyCavalry(), true),
                FactoryUnit.CreateUnit("HeavyInfantry", () => new ByzantiumHeavyInfantry(), true),
                FactoryUnit.CreateUnit("Knight", () => new ByzantiumKnight(), true),
                FactoryUnit.CreateUnit("LightInfantry", () => new ByzantiumLightInfantry(), true),
                FactoryUnit.CreateUnit("Scout", () => new ByzantiumScout(), true),
                FactoryUnit.CreateUnit("Spearman", () => new ByzantiumSpearman(), true),
                FactoryUnit.CreateUnit("Cataphract", () => new ByzantiumCataphract(), false),
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

        public List<ITroop> CreateMultipleTroops(string name, int count)
        {
            var troops = new List<ITroop>();
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

            for (int i = 0; i < count; i++)
            {
                troops.Add(unit.CreateInstance());
            }

            return troops;
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
