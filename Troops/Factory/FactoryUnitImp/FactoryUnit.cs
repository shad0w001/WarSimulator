using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Troops.BaseInterfaces;

namespace WarSimulator.Troops.Factory.FactoryUnitImp
{
    public class FactoryUnit : IFactoryUnit
    {
        public string Name { get; set; }
        public Func<ITroop> CreationFunction { get; set; }
        public bool IsUnlocked { get; set; }

        private FactoryUnit(string name, Func<ITroop> function, bool isUnlocked)
        {
            Name = name;
            CreationFunction = function;
            IsUnlocked = isUnlocked;
        }

        public static FactoryUnit CreateUnit(string name, Func<ITroop> function, bool isUnlocked)
        {
            return new FactoryUnit(name, function, isUnlocked);
        }

        public ITroop CreateInstance()
        {
            return CreationFunction();
        }
    }
}
