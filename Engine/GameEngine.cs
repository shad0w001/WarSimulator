using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Battles;
using WarSimulator.Commands;
using WarSimulator.Engine.SetupSchemas;
using WarSimulator.Nations;
using WarSimulator.Shop.Base;
using WarSimulator.Shop.Strategy;
using WarSimulator.Timespan.Cycles;
using WarSimulator.Timespan.Eras;

namespace WarSimulator.Engine
{
    public class GameEngine : IGameEngine
    {
        private static GameEngine _instance;
        public ITroopShopManager _shopManager { get; set; }
        public IBattleManager _battleManager { get; set; }
        public ISetupSchema _schema { get; set; }
        public CommandManager _commandManager { get; set; }
        private bool IsPlaying { get; set; }

        private GameEngine()
        {
            _schema = new TaskSetupSchema();
            _shopManager = new TroopShopManager();
            _battleManager = new BattleManager();
            _commandManager = CommandManager.GetInstance();
            IsPlaying = true;
        }

        public static GameEngine GetInstance()
        {
            if(_instance == null)
            {
                _instance = new GameEngine();
            }
            return _instance;
        }

        public void Run()
        {
            Console.WriteLine("Welcome to the War Simulator!");
            Console.WriteLine("To start the game type /game start");
            Console.WriteLine("To exit write /game exit");

            var userInput = Console.ReadLine();
            _commandManager.ExecuteGameCommand(userInput);

            var bulgaria = new Bulgaria();
            var byzantium = new Byzantium();

            List<INation> nations = [bulgaria, byzantium];
            var eras = _schema.SetupSchema();

            while (IsPlaying)
            {
                for (int i = 0; i < eras.Count; i++)
                {
                    if (!IsPlaying)
                    {
                        break;
                    }

                    Era? era = eras[i];
                    era.ApplyBuffs(nations);

                    _shopManager.ExecuteShoppingStrategy(bulgaria, ManualTroopShopStrategy.CreateStrategy());
                    _shopManager.ExecuteShoppingStrategy(byzantium, AutomaticTroopShopStrategy.CreateStrategy());

                    Console.WriteLine($"Era {i + 1}");

                    for (int j = 0; j < era._cycles.Count; j++)
                    {
                        Cycle cycle = era._cycles[j];
                        Console.WriteLine($"Cycle {j + 1}");
                        cycle.ApplyBuffs(nations);

                        if (!_battleManager.CheckIfNationsHaveArmies(nations))
                        {
                            Stop();
                            break;
                        }

                        _battleManager.ExecuteBattleCycle(bulgaria, byzantium);

                        userInput = Console.ReadLine();
                        //_commandManager.ExecuteGameCommand(userInput);
                    }
                }
            }


        }
        private void Stop()
        {
            IsPlaying = false;
        }
    }
}
