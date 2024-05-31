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
        public ITroopShopStrategy _buyingStrategy { get; set; }
        public void ExecuteShoppingStrategy(INation nation);
    }
}
