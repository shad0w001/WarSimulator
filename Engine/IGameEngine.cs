using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Battles;
using WarSimulator.Engine.SetupSchemas;
using WarSimulator.Shop.Base;

namespace WarSimulator.Engine
{
    public interface IGameEngine
    {
        public ITroopShopManager _shopManager { get; set; }
        public IBattleManager _battleManager { get; set; }
        public ISetupSchema _schema { get; set; }
        public void Run();
    }
}
