using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Nations;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.Factory.FactoryUnitImp;
using WarSimulator.Troops.TroopTypes;

namespace WarSimulator.Troops.Factory
{
    public interface ITroopFactory
    {
        public List<IFactoryUnit> _factoryUnits { get; set; }
        public ITroop CreateTroop(string name);
        public void UnlockTroop(string name);
    }
}
