using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Nations;
using WarSimulator.Shop.ShoppingCartImp;

namespace WarSimulator.Shop.Strategy
{
    public interface ITroopShopStrategy
    {
        public IShoppingCart Execute(INation nation, Dictionary<string, int> prices);
    }
}
