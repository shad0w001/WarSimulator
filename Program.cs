using WarSimulator.Nations;
using WarSimulator.Troops.Factory;

var bulgaria = new Bulgaria();
var bulgarianFactory = new BulgarianTroopFactory();

var light = bulgarianFactory.CreateLightInfantry();
var gun = bulgarianFactory.CreateGunslinger();

bulgaria.Troops.Add(light);
bulgaria.Troops.Add(gun);

foreach(var troop in bulgaria.Troops)
{
    Console.WriteLine(troop.GetType());
}