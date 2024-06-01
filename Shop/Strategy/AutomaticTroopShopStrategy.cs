using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Nations;
using WarSimulator.Shop.ShoppingCartImp;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.Factory.FactoryUnitImp;

namespace WarSimulator.Shop.Strategy
{
    public class AutomaticTroopShopStrategy : ITroopShopStrategy
    {
        private int numberOfStrategies { get; set; }
        private Random random { get; set; }

        public AutomaticTroopShopStrategy()
        {
            numberOfStrategies = 10;
            random = new Random();
        }
        public IShoppingCart Execute(INation nation, Dictionary<string, int> prices)
        {
            int gold = nation.Gold;

            // Extract units and their attack values
            var availableUnits = GetUnitStats(nation);

            // Sort available units by attack-to-price ratio (higher is better)
            availableUnits = availableUnits.OrderByDescending(u => (double)u.Item2 / u.Item3).ToList();

            var selectedStrategy = SelectStrategy(availableUnits, gold);

            var cart = ConvertStrategyToShoppingCart(selectedStrategy);

            return cart;
        }

        private List<Tuple<string, double, int>> GetUnitStats(INation nation)
        {
            var availableUnits = new List<Tuple<string, double, int>>(); // Tuple<unit, attack, price>

            foreach (FactoryUnit unit in nation._rectruitmentCenter._factoryUnits)
            {
                if (!unit.IsUnlocked)
                {
                    continue;
                }

                var troop = unit.CreationFunction();
                var troopType = troop.GetType();
                PropertyInfo attackProperty = troopType.GetProperties().Where(property => property.Name == "Attack").FirstOrDefault();
                PropertyInfo priceProperty = troopType.GetProperties().Where(property => property.Name == "Price").FirstOrDefault();

                if (attackProperty is null && priceProperty is null)
                {
                    Console.WriteLine("Attack or Price not found for unit: " + unit.Name);
                    continue;
                }

                double attack = (double)attackProperty.GetValue(troop);
                int price = (int)priceProperty.GetValue(troop);
                availableUnits.Add(Tuple.Create(unit.Name, attack, price));
            }

            return availableUnits;
        }
        private Dictionary<string, string> SelectStrategy(List<Tuple<string, double, int>> availableUnits, int gold)
        {
            List<Dictionary<string, int>> strategies = new List<Dictionary<string, int>>();

            for (int i = 0; i < numberOfStrategies; i++)
            {
                Dictionary<string, int> strategy = new Dictionary<string, int>();
                int remainingGold = gold;

                bool spendFullGold = (random.NextDouble() <= 0.5); // 50% chance to spend 100%, 50% to spend 90%
                
                int targetGold;
                if (spendFullGold)
                {
                    targetGold = (int)(gold * 0.9);
                }
                else
                {
                    targetGold = (int)(gold * 0.7);
                }


                while (remainingGold >= 10)
                {
                    var unit = availableUnits[random.Next(availableUnits.Count)];
                    string unitName = unit.Item1;
                    int unitCost = unit.Item3;

                    // Ensure the unit can be afforded
                    if (unitCost <= remainingGold)
                    {
                        // Add the unit to the strategy
                        if (!strategy.ContainsKey(unitName))
                        {
                            strategy[unitName] = 0;
                        }
                        strategy[unitName]++;
                        remainingGold -= unitCost;
                    }
                }
                remainingGold = gold;
                strategies.Add(strategy);
            }

            // Select a random strategy from the list of strategies
            Dictionary<string, int> selectedStrategy = strategies[random.Next(strategies.Count)];

            // Convert the dictionary to the desired format with string values
            Dictionary<string, string> result = selectedStrategy.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString());

            return result;
        }
        private IShoppingCart ConvertStrategyToShoppingCart(Dictionary<string, string> strategy)
        {
            var cart = new ShoppingCart();

            foreach (var strategyKey in strategy.Keys)
            {
                var items = new ShoppingCartItem
                {
                    Name = strategyKey,
                    Amount = strategy[strategyKey]
                };
                cart.AddItemsToCart(items);
            }

            return cart;
        }
    }
}
