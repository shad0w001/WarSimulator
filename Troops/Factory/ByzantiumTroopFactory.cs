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
            _factoryUnits = new List<IFactoryUnit>();

            _factoryUnits.Add(new FactoryUnit("Archer", () => new ByzantiumArcher(), true));
            _factoryUnits.Add(new FactoryUnit("ArmoredInfantry", () => new ByzantiumArmoredInfantry(), true));
            _factoryUnits.Add(new FactoryUnit("Gunslinger", () => new ByzantiumGunslinger(), true));
            _factoryUnits.Add(new FactoryUnit("HeavyCavalry", () => new ByzantiumHeavyCavalry(), true));
            _factoryUnits.Add(new FactoryUnit("HeavyInfantry", () => new ByzantiumHeavyInfantry(), true));
            _factoryUnits.Add(new FactoryUnit("Knight", () => new ByzantiumKnight(), true));
            _factoryUnits.Add(new FactoryUnit("LightInfantry", () => new ByzantiumLightInfantry(), true));
            _factoryUnits.Add(new FactoryUnit("Scout", () => new ByzantiumScout(), true));
            _factoryUnits.Add(new FactoryUnit("Spearman", () => new ByzantiumSpearman(), true));
            _factoryUnits.Add(new FactoryUnit("Cataphract", () => new ByzantiumCataphract(), false));
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
