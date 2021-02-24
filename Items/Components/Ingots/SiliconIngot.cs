using DSPCalculator.Items.Ores;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class SiliconIngot : BaseItem
    {
        public SiliconIngot()
        {
            MainRecipe = new Recipe().WithInput<SiliconOre>(2).WithOutput<SiliconIngot>(1).WithCycleTime(2).ProducedInSmelter();
        }
    }
}
