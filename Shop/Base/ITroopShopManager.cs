using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Nations;
using WarSimulator.Shop.Strategy;

namespace WarSimulator.Shop.Base
{
    public interface ITroopShopManager
    {
        public void ExecuteShoppingStrategy(INation nation, ITroopShopStrategy strategy);
    }
}
