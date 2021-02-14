using DSPCalculator.Items.Ores;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class TitaniumIngot : BaseItem
    {
        public TitaniumIngot()
        {
            MainRecipe = new Recipe().WithInput<TitaniumOre>(2).WithCycleTime(2).WithOutput<TitaniumIngot>(1);
        }
    }
}
