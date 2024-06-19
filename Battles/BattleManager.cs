using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Nations;
using WarSimulator.Troops.BaseInterfaces;

namespace WarSimulator.Battles
{
    public class BattleManager : IBattleManager
    {
        private Random random = new Random();
        public void ExecuteBattleCycle(INation nationOne, INation nationTwo)
        {
            if(!CheckIfNationsHaveArmies([nationOne, nationTwo]))
            {
                return;
            }

            if (random.NextDouble() > 0.8)
            {
                Console.WriteLine("No battle this cycle");
                return;
            }

            var nationOneActiveTroops = GetRandomTroops(nationOne);
            var nationTwoActiveTroops = GetRandomTroops(nationTwo);

            var nationOneAttacks = GetAttackChances(nationOneActiveTroops);
            var nationTwoAttacks = GetAttackChances(nationTwoActiveTroops);

            PerformAttacks(
                nationOne,
                nationOneActiveTroops,
                nationOneAttacks,
                nationTwo,
                nationTwoActiveTroops);

            PerformAttacks(
                nationTwo,
                nationTwoActiveTroops,
                nationTwoAttacks,
                nationOne,
                nationOneActiveTroops);

        }
        public bool CheckIfNationsHaveArmies(List<INation> nations)
        {
            foreach( var nation in nations)
            {
                if(nation.Army.Count == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private void Attack(ITroop attacker, ITroop defender)
        {
            bool isRanged = attacker is IAccuracy;
            double accuracy = 1.0;

            if (isRanged)
            {
                accuracy = ((IAccuracy)attacker).Accuracy / 100.0;
            }

            bool attackHits = random.NextDouble() < accuracy;

            if (!attackHits)
            {
                Console.WriteLine("Attacker missed");
                return;
            }

            double evasionChance = 1.0 / defender.Speed;
            bool defenderEvaded = random.NextDouble() <= evasionChance;

            if (defenderEvaded)
            {
                Console.WriteLine("Defender evaded the attack");
                return;
            }

            double damage = attacker.Attack - defender.Defence;
            if (damage < 0)
            {
                damage = 0;
            }

            defender.Life -= damage;
            Console.WriteLine($"({attacker.Life}){attacker.GetType().Name} dealt {damage} damage to ({defender.Life}){defender.GetType().Name}");
        }
        private List<ITroop> GetRandomTroops(INation nation)
        {
            var troops = nation.Army;

            //if they are less then 10 troops, return all troops
            if(nation.Army.Count < 10)
            {
                return nation.Army;
            }

            //90% of troops
            int lowestAmountOfTroopsInBattle = (int)(troops.Count * 0.9);

            int randomExtraAmount = random.Next((int)(troops.Count * 0.1));

            int troopCount = lowestAmountOfTroopsInBattle + randomExtraAmount;

            var activeTroops = troops.OrderBy(x => random.Next()).Take(troopCount).ToList();

            return activeTroops;
        }
        private int GetAttackChances(List<ITroop> activeArmy)
        {
            int maxAttacks = activeArmy.Count;

            int baseAttacks = (int)(activeArmy.Count * 0.60);
            double randomFactor = random.NextDouble() * 0.8 + 1.0;
            int numberOfAttacks = (int)(baseAttacks * randomFactor);

            numberOfAttacks = Math.Min(numberOfAttacks, maxAttacks);

            return numberOfAttacks;
        }
        private ITroop PickRandomTroop(List<ITroop> activeTroopsList)
        {
            if(activeTroopsList.Count == 0)
            {
                return null;
            }

            int randomIndex = random.Next(activeTroopsList.Count);
            var troop = activeTroopsList[randomIndex];

            if(troop is null)
            {
                return null;
            }

            return activeTroopsList[randomIndex];
        }
        private void PerformAttacks(
            INation attackingNation,
            List<ITroop> attackingNationTroops,
            int attackerNumberOfAttacks,
            INation defendingNation,
            List<ITroop> defendingNationTroops)
        {
            for(int i = 0;  i < attackerNumberOfAttacks - 1; i++)
            {
                if (!CheckIfNationsHaveArmies([attackingNation, defendingNation]))
                {
                    return;
                }

                var attacker = PickRandomTroop(attackingNationTroops);
                var defender = PickRandomTroop(defendingNationTroops);

                Attack(attacker, defender);

                if(defender.Life <= 0)
                {
                    defendingNationTroops.Remove(defender);
                    defendingNation.Army.Remove(defender);
                }
            }
        }
    }
}
