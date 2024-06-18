using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WarSimulator.Commands;
using WarSimulator.Nations;
using WarSimulator.Shop.ShoppingCartImp;

namespace WarSimulator.Shop.Strategy
{
    public class ManualTroopShopStrategy : ITroopShopStrategy
    {
        public static ManualTroopShopStrategy CreateStrategy()
        {
            return new ManualTroopShopStrategy();
        }
        public IShoppingCart Execute(INation nation, Dictionary<string, int> prices)
        {
            var cart = new ShoppingCart();

            ShowShopInterface(prices);

            //to be implemented when i figure out commands
            while (cart.IsShopping)
            {
                ShowShopInterface(prices);
                DisplayCurrentBudget(nation, cart, prices);
                DisplayCartItems(cart);
                var userInput = Console.ReadLine();
                CommandManager.GetInstance().ExecuteShopCommand(userInput, cart);
            }

            return cart;
        }

        private void ShowShopInterface(Dictionary<string, int> prices)
        {
            Console.Clear();
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
            Console.WriteLine("/cart confirm - confirm your purchases\n");
        }
        private void DisplayCartItems(IShoppingCart cart)
        {
            if(cart.Items.Count == 0)
            {
                Console.WriteLine("There are no items in the cart.");
                return;
            }

            if(cart.Items.Count > 0)
            {
                Console.WriteLine("Current items: \n");
                foreach (var item in cart.Items)
                {
                    Console.WriteLine($"{item.Amount}x {item.Name}");
                }
            }
        }
        private void DisplayCurrentBudget(INation nation, IShoppingCart cart, Dictionary<string, int> prices)
        {
            if(cart.Items.Count == 0)
            {
                Console.WriteLine(nation.Gold);
                return;
            }

            int totalPrice = CalculateTotal(cart, prices);

            totalPrice = CheckForAndPreventOverspending(nation, cart, prices, totalPrice);   

            Console.WriteLine($"Current budget: {nation.Gold - totalPrice} ({nation.Gold} - {totalPrice})");
        }
        private int CalculateTotal(IShoppingCart cart, Dictionary<string, int> prices)
        {
            int totalPrice = 0;

            foreach (var item in cart.Items)
            {
                if (!prices.TryGetValue(item.Name, out int price))
                {
                    continue;
                }

                if (int.TryParse(item.Amount, out int amount))
                {
                    totalPrice += price * amount;
                }

            }

            return totalPrice;
        }
        private int CheckForAndPreventOverspending(INation nation, IShoppingCart cart, Dictionary<string, int> prices, int total)
        {
            if(nation.Gold >= total)
            {
                return total;
            }
            else
            {
                int count = 0;
                while(nation.Gold < total)
                {
                    cart.RemoveLastItemFromCart();
                    total = CalculateTotal(cart, prices);
                    count++;
                }
                Console.WriteLine($"Due to budget overflow, your last {count} purchases were removed.");
                return total;
            }
        }
    }
}
