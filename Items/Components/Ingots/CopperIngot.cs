using DSPCalculator.Items.Ores;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class CopperIngot : BaseItem
    {
        public CopperIngot()
        {
            MainRecipe = new Recipe().WithInput<CopperOre>(1).WithOutput<CopperIngot>(1).WithCycleTime(1);
        }
    }
}
