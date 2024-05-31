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
            _factoryUnits = new List<IFactoryUnit>();

            _factoryUnits.Add(new FactoryUnit("Archer", () => new BulgarianArcher(), true));
            _factoryUnits.Add(new FactoryUnit("ArmoredInfantry", () => new BulgarianArmoredInfantry(), true));
            _factoryUnits.Add(new FactoryUnit("Gunslinger", () => new BulgarianGunslinger(), true));
            _factoryUnits.Add(new FactoryUnit("HeavyCavalry", () => new BulgarianHeavyCavalry(), true));
            _factoryUnits.Add(new FactoryUnit("HeavyInfantry", () => new BulgarianHeavyInfantry(), true));
            _factoryUnits.Add(new FactoryUnit("Knight", () => new BulgarianKnight(), true));
            _factoryUnits.Add(new FactoryUnit("LightInfantry", () => new BulgarianLightInfantry(), true));
            _factoryUnits.Add(new FactoryUnit("Scout", () => new BulgarianScout(), true));
            _factoryUnits.Add(new FactoryUnit("Spearman", () => new BulgarianSpearman(), true));
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
