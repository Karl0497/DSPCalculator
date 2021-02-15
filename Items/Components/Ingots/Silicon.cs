using DSPCalculator.Items.Ores;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class Silicon : BaseItem
    {
        public Silicon()
        {
            MainRecipe = new Recipe().WithInput<SiliconOre>(2).WithOutput<Silicon>(1).WithCycleTime(2);
        }
    }
}
