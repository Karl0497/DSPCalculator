using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class TitaniumCrystal : BaseItem
    {
        public TitaniumCrystal()
        {
            MainRecipe = new Recipe().WithInput<OrganicCrystal>().WithInput<TitaniumIngot>(3).WithCycleTime(4).WithOutput<TitaniumCrystal>().ProducedInAssembler();
        }
    }
}
