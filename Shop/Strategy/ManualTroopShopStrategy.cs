using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WarSimulator.Nations;
using WarSimulator.Shop.ShoppingCartImp;

namespace WarSimulator.Shop.Strategy
{
    public class ManualTroopShopStrategy : ITroopShopStrategy
    {
        public IShoppingCart Execute(INation nation, Dictionary<string, int> prices)
        {
            var cart = new ShoppingCart();

            Console.WriteLine("Welcome to the shop! \n");
            Console.WriteLine("Here is a list of avaiable units: \n");
            foreach (var item in prices)
            {
                Console.WriteLine($"{item.Key}: {item.Value}g");
            }

            Console.WriteLine("\nHere are the available commands:");
            Console.WriteLine("/cart buy [name of troop] [ammount of troop] - adds the specified ammount of the specified troop to the cart");
            Console.WriteLine("/cart remove [name of troop] [ammount of troop] - removes the specified ammount of the specified troop to the cart");
            Console.WriteLine("/cart clear - clears all items from the cart");
            Console.WriteLine("/cart confirm - confirm your purchases");

            //to be implemented when i figure out commands

            var item1 = new ShoppingCartItem
            {
                Name = "Knight",
                Amount = "190"
            };

            cart.AddItemsToCart(item1);

            return cart;
        }
    }
}
