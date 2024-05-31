using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WarSimulator.Nations;

namespace WarSimulator.Shop.Strategy
{
    public class ManualTroopShopStrategy : ITroopShopStrategy
    {
        public void Execute(INation nation, Dictionary<string, int> prices)
        {
            Console.WriteLine("Manuan Purchasing Strategy");
            Console.WriteLine("Here is a list of avaiable units: \n");
            foreach (var item in prices)
            {
                Console.WriteLine($"{item.Key}: ${item.Value}");
            }

            string[] args = ["Archer", "2"];
            string[] args2 = ["Knight", "100000"];
            string[] args3 = ["0", "1"];
            string[] args4 = ["Knight", "-5"];
            List<string[]> allArgs = [args, args2];

            foreach (var item in allArgs)
            {
                string name = item[0];

                if (!TroopExists(nation, name))
                {
                    Console.WriteLine("Troop type does not exist");
                    continue;
                }

                int ammount = int.Parse(item[1]);

                if (ammount <= 0)
                {
                    Console.WriteLine("Cannot create negative number of troops");
                    continue;
                }

                var totalPrice = GetPrice(nation, name, ammount);

                if (!CanNationAffordTroops(nation, totalPrice))
                {
                    Console.WriteLine($"Nation cannot afford to purchase {ammount} x {name}.");
                    continue;
                }

                if(ammount == 1)
                {
                    var troop = nation._rectruitmentCenter.CreateTroop(name);

                    if(troop is null)
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

                    if(troops.Count == 0 || troops is null)
                    {
                        Console.WriteLine("Troop type not found");
                        continue;
                    }

                    foreach(var troop in troops)
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

        private int GetPrice(INation nation, string name, int ammount)
        {
            return nation._rectruitmentCenter._factoryUnits.FirstOrDefault(unit => unit.Name.Equals(name.ToString(), StringComparison.OrdinalIgnoreCase)).CreationFunction().Price * ammount;
        }
    }
}
