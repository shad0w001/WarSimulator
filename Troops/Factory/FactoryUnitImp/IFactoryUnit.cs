using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.BaseInterfaces;

namespace WarSimulator.Troops.Factory.FactoryUnitImp
{
    public interface IFactoryUnit
    {
        public string Name { get; set; }
        public Func<ITroop> CreationFunction { get; set; }
        public bool IsUnlocked { get; set; }

        public ITroop CreateInstance();
    }
}
