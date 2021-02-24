using DSPCalculator.Items.Ores;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class IronIngot : BaseItem
    {
        public IronIngot()
        {
            MainRecipe = new Recipe().WithInput<IronOre>(1).WithOutput<IronIngot>(1).WithCycleTime(1).ProducedInSmelter();
        }
    }
}
