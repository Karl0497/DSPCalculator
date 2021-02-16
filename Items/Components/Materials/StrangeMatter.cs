using DSPCalculator.Items.Components.LiquidAndGas;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class StrangeMatter : BaseItem
    {
        public StrangeMatter()
        {
            MainRecipe = new Recipe().WithInput<ParticleContainer>(2).WithInput<IronIngot>(2).WithInput<Deuterium>(10).WithOutput<StrangeMatter>().WithCycleTime(8);
        }
    }
}
