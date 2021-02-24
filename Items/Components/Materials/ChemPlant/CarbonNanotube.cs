using DSPCalculator.Items.Components.Ores;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class CarbonNanotube : BaseItem
    {
        public CarbonNanotube()
        {
            MainRecipe = new Recipe().WithInput<Graphene>(3).WithInput<TitaniumIngot>().WithOutput<CarbonNanotube>(2).WithCycleTime(4);
            AlternativeRecipe = new Recipe().WithBasicProduction<SpiniformStalagmiteCrystal, CarbonNanotube>(2, 2, 4);
        }
    }
}
