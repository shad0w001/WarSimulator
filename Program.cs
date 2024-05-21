using System.Collections.Concurrent;
using WarSimulator.Buffs.BuffImplementations;
using WarSimulator.Buffs.BuffStorageImplementations;
using WarSimulator.Nations;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.Bulgaria;
using WarSimulator.Troops.Factory;
using WarSimulator.Troops.TroopTypes;

var bulgaria = new Bulgaria();
var bulgarianFactory = new BulgarianTroopFactory();

var light = bulgarianFactory.CreateLightInfantry();
var gun = bulgarianFactory.CreateGunslinger();

bulgaria.Army.Add(light);
bulgaria.Army.Add(gun);

Console.WriteLine(bulgaria.Gold);
foreach(var troop in bulgaria.Army)
{
    Console.WriteLine($"{troop.GetType().Name}: Attack: {troop.Attack}");
}

var eraBuffs = new EraBuffStorage();

eraBuffs.AddBuff(new NationGoldPercentageBuff(30));
eraBuffs.AddBuff(new TroopSingleStatPercentageBuff(25, "Attack"));
eraBuffs.AddBuff(new TroopAllStatsPercantageBuff(10));

eraBuffs.ApplyTroopBuffs(bulgaria.Army);

Console.WriteLine($"\nAfter changes \n");
Console.WriteLine(bulgaria.Gold);
foreach (var troop in bulgaria.Army)
{
    Console.WriteLine($"{troop.GetType().Name}: Attack: {troop.Attack}");
}