using DSPCalculator.Items.Components.Liquid;
using DSPCalculator.Items.Components.Materials;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Ingots
{
    public class TitaniumAlloy : BaseItem
    {
        public TitaniumAlloy()
        {
            MainRecipe = new Recipe().WithInput<TitaniumIngot>(4).WithInput<Steel>(4).WithInput<SulfuricAcid>(8).WithOutput<TitaniumAlloy>(4).WithCycleTime(12).ProducedInSmelter();
        }
    }
}
