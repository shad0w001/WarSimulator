using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Buffs.BaseBuffTypes;
using WarSimulator.Nations;
using WarSimulator.Shop.Strategy;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.Factory.FactoryUnitImp;

namespace WarSimulator.Shop.Base
{
    public class TroopShopManager : ITroopShopManager
    {
        public ITroopShopStrategy _buyingStrategy { get; set; }

        public TroopShopManager(ITroopShopStrategy buyingStrategy)
        {
            _buyingStrategy = buyingStrategy;
        }

        public void ExecuteShoppingStrategy(INation nation)
        {
            var prices = GetTroopPrices(nation);

            _buyingStrategy.Execute(nation, prices);
        }

        private Dictionary<string, int> GetTroopPrices(INation nation)
        {
            var dictionary = new Dictionary<string, int>();

            foreach (FactoryUnit unit in nation._rectruitmentCenter._factoryUnits)
            {
                var troop = unit.CreationFunction();

                var troopType = troop.GetType();

                PropertyInfo[] troopProperties = troopType.GetProperties();

                var property = troopProperties.Where(property => property.Name == "Price").FirstOrDefault();

                if (property is null)
                {
                    Console.WriteLine("Price not found");
                    continue;
                }

                var price = (int)property.GetValue(troop);

                dictionary.Add(unit.Name, price);
            }

            return dictionary;
        }
    }
}
