using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Nations;
using WarSimulator.Shop.ShoppingCartImp;

namespace WarSimulator.Shop.Strategy
{
    public class AutomaticTroopShopStrategy : ITroopShopStrategy
    {
        public IShoppingCart Execute(INation nation, Dictionary<string, int> prices)
        {
            Console.WriteLine("Manuan Purchasing Strategy");
            Console.WriteLine("Here is a list of avaiable units: \n");
            foreach (var item in prices)
            {
                Console.WriteLine($"{item.Key}: ${item.Value}");
            }

            return new ShoppingCart();
        }
    }
}
