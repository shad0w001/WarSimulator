using System.Collections.Concurrent;
using WarSimulator.Battles;
using WarSimulator.Buffs.BuffImplementations;
using WarSimulator.Buffs.BuffStorageImplementations;
using WarSimulator.Nations;
using WarSimulator.Shop.Base;
using WarSimulator.Shop.Strategy;
using WarSimulator.Timespan.Eras;
using WarSimulator.Timespan.Cycles;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.Bulgaria;
using WarSimulator.Troops.Factory;
using WarSimulator.Troops.TroopTypes;
using WarSimulator.Troops.Byzantium;

var bulgaria = new Bulgaria();
var byzantium = new Byzantium();
byzantium.Gold = 10000;
bulgaria.Gold = 10000;


var shopManager = new TroopShopManager();
shopManager.ExecuteShoppingStrategy(byzantium, new AutomaticTroopShopStrategy());
shopManager.ExecuteShoppingStrategy(bulgaria, new ManualTroopShopStrategy());


//Eras from task
//Era1
Era.SetupEra()
    .AddBuff(new NationGoldFlatAmountBuff(10000, typeof(Bulgaria)))
    .AddBuff(new NationGoldFlatAmountBuff(10000, typeof(Byzantium)))
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle()
            .AddBuff(new TroopAllStatsPercantageBuff(10, typeof(BulgarianLightInfantry)))
            .AddBuff(new TroopAllStatsPercantageBuff(15, typeof(ByzantiumLightInfantry)))
            .AddBuff(new TroopAllStatsPercantageBuff(5, typeof(BulgarianArcher)))
            .AddBuff(new TroopAllStatsPercantageBuff(5, typeof(ByzantiumArcher))))
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle());

//Era2
Era.SetupEra()
    .AddBuff(new NationGoldPercentageBuff(30, typeof(Bulgaria)))
    .AddBuff(new NationGoldPercentageBuff(30, typeof(Byzantium)))
        .AddCycle(Cycle.CreateCycle()
            .AddBuff(new TroopAllStatsPercantageBuff(10, typeof(BulgarianKnight))))
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle()
            .AddBuff(new TroopAllStatsPercantageBuff(7, typeof(ByzantiumArcher))))
        .AddCycle(Cycle.CreateCycle()
            .AddBuff(new TroopAllStatsPercantageBuff(5, typeof(BulgarianLightInfantry))))
        .AddCycle(Cycle.CreateCycle()
            .AddBuff(new TroopAllStatsPercantageBuff(4, typeof(ByzantiumLightInfantry))))
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle()
            .AddBuff(new TroopAllStatsPercantageBuff(10, typeof(ByzantiumKnight))))
            .AddBuff(new TroopAllStatsPercantageBuff(10, typeof(ByzantiumKnight)))
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle());

Era.SetupEra()
    .AddBuff(new NationGoldPercentageBuff(30, typeof(Bulgaria)))
    .AddBuff(new NationGoldPercentageBuff(30, typeof(Byzantium)))
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle()
            .AddBuff(new TroopAllStatsPercantageBuff(10, typeof(BulgarianKnight))))
        .AddCycle(Cycle.CreateCycle()
            .AddBuff(new TroopAllStatsPercantageBuff(7, typeof(ByzantiumArcher))))
        .AddCycle(Cycle.CreateCycle()
            .AddBuff(new TroopAllStatsPercantageBuff(5, typeof(BulgarianLightInfantry)))
            .AddBuff(new TroopAllStatsPercantageBuff(6, typeof(ByzantiumLightInfantry))))
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle())
        .AddCycle(Cycle.CreateCycle());

var battleManager = new BattleManager();
battleManager.ExecuteBattleCycle(bulgaria, byzantium);