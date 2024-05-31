﻿using System.Collections.Concurrent;
using WarSimulator.Buffs.BuffImplementations;
using WarSimulator.Buffs.BuffStorageImplementations;
using WarSimulator.Nations;
using WarSimulator.Troops.BaseInterfaces;
using WarSimulator.Troops.Bulgaria;
using WarSimulator.Troops.Factory;
using WarSimulator.Troops.TroopTypes;

var bulgaria = new Bulgaria();

var light = bulgaria._rectruitmentCenter.CreateTroop("LightInfantry");
var light2 = bulgaria._rectruitmentCenter.CreateTroop("LightInfantry");
var gun = bulgaria._rectruitmentCenter.CreateTroop("Gunslinger");

bulgaria.Army.Add(light);
bulgaria.Army.Add(light2);
bulgaria.Army.Add(gun);

Console.WriteLine(bulgaria.Gold);
foreach(var troop in bulgaria.Army)
{
    Console.WriteLine($"{troop.GetType().Name}: Attack:  {troop.Attack}");
}

var eraBuffs = new EraBuffManager();
var cycleBuffs = new CycleBuffManager();

eraBuffs.AddBuff(new NationGoldPercentageBuff(10, typeof(Bulgaria)));
eraBuffs.AddBuff(new TroopSingleStatPercentageBuff(25, "Attack", typeof(BulgarianLightInfantry)));
eraBuffs.AddBuff(new TroopAllStatsPercantageBuff(10, typeof(BulgarianGunslinger)));

cycleBuffs.AddBuff(new NationGoldPercentageBuff(10, typeof(Bulgaria)));
cycleBuffs.AddBuff(new TroopSingleStatPercentageBuff(25, "Attack", typeof(BulgarianLightInfantry)));
cycleBuffs.AddBuff(new TroopAllStatsPercantageBuff(10, typeof(BulgarianGunslinger)));

eraBuffs.ApplyTroopBuffs(bulgaria.Army);
eraBuffs.ApplyNationBuffs(bulgaria);

Console.WriteLine($"\nAfter changes \n");
Console.WriteLine(bulgaria.Gold);
foreach (var troop in bulgaria.Army)
{
    Console.WriteLine($"{troop.GetType().Name}: Attack: {troop.Attack}");
}

cycleBuffs.ApplyTroopBuffs(bulgaria.Army);
cycleBuffs.ApplyNationBuffs(bulgaria);

Console.WriteLine($"\nAfter cycle buffs \n");
Console.WriteLine(bulgaria.Gold);
foreach (var troop in bulgaria.Army)
{
    Console.WriteLine($"{troop.GetType().Name}: Attack: {troop.Attack}");
}