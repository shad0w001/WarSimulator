using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Buffs.BaseBuffTypes;
using WarSimulator.Nations;
using WarSimulator.Shop.ShoppingCartImp;
using WarSimulator.Shop.Strategy;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.Factory.FactoryUnitImp;

namespace WarSimulator.Shop.Base
{
    public class TroopShopManager : ITroopShopManager
    {
        public void ExecuteShoppingStrategy(INation nation, ITroopShopStrategy _buyingStrategy)
        { 
            var prices = GetTroopPrices(nation);

            var arguments = _buyingStrategy.Execute(nation, prices);

            BuyTroops(nation, prices, arguments);
        }

        private Dictionary<string, int> GetTroopPrices(INation nation)
        {
            var dictionary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (FactoryUnit unit in nation._rectruitmentCenter._factoryUnits)
            {
                if (!unit.IsUnlocked)
                {
                    continue;
                }

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
        private void BuyTroops(INation nation, Dictionary<string, int> prices, IShoppingCart arguments)
        {
            foreach (var item in arguments.Items)
            {
                string name = item.Name;

                if (!TroopExists(nation, name))
                {
                    Console.WriteLine("Troop type does not exist");
                    continue;
                }

                int ammount = 0;
                if (!int.TryParse(item.Amount, out int validAmmount))
                {
                    Console.WriteLine("Invalid number of troops");
                    continue;
                }
                ammount = int.Parse(item.Amount);


                if (ammount <= 0)
                {
                    Console.WriteLine("Cannot create negative number of troops");
                    continue;
                }

                var totalPrice = CalculateTotalPrice(nation, name, ammount);

                if (!CanNationAffordTroops(nation, totalPrice))
                {
                    Console.WriteLine($"Nation cannot afford to purchase {ammount} x {name}.");
                    continue;
                }

                if (ammount == 1)
                {
                    var troop = nation._rectruitmentCenter.CreateTroop(name);

                    if (troop is null)
                    {
                        Console.WriteLine("Troop type not found");
                        continue;
                    }

                    nation.Gold -= totalPrice;
                    nation.Army.Add(troop);
                }
                else
                {
                    var troops = nation._rectruitmentCenter.CreateMultipleTroops(name, ammount);

                    if (troops.Count == 0 || troops is null)
                    {
                        Console.WriteLine("Troop type not found");
                        continue;
                    }

                    foreach (var troop in troops)
                    {
                        nation.Army.Add(troop);
                    }

                    nation.Gold -= totalPrice;
                }
            }
        }

        private bool TroopExists(INation nation, string arg)
        {
            if(nation._rectruitmentCenter._factoryUnits.Where(unit => unit.Name.Equals(arg.ToString(), StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault() is not null)
            {
                return true;
            }
            return false;
        }

        private bool CanNationAffordTroops(INation nation, int price)
        {
            if(nation.Gold - price < 0)
            {
                return false;
            }

            return true;
        }

        private int CalculateTotalPrice(INation nation, string name, int ammount)
        {
            return nation._rectruitmentCenter._factoryUnits.FirstOrDefault(unit => unit.Name.Equals(name.ToString(), StringComparison.OrdinalIgnoreCase)).CreationFunction().Price * ammount;
        }
    }
}
