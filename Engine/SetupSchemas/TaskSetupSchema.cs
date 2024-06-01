using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Buffs.BuffImplementations;
using WarSimulator.Nations;
using WarSimulator.Timespan.Cycles;
using WarSimulator.Timespan.Eras;
using WarSimulator.Troops.Bulgaria;
using WarSimulator.Troops.Byzantium;

namespace WarSimulator.Engine.SetupSchemas
{
    public class TaskSetupSchema : ISetupSchema
    {
        public List<Era> SetupSchema()
        {
            var era1 = Era.SetupEra()
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
            var era2 = Era.SetupEra()
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

            //Era3
            var era3 = Era.SetupEra()
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

            List<Era> eras = [era1, era2, era3];
            return eras;
        }
    }
}
