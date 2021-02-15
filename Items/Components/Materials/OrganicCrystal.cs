using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class OrganicCrystal : BaseItem
    {
        public OrganicCrystal()
        {
            MainRecipe = new Recipe().WithInput<Plastic>(2).WithInput<RefinedOil>().WithInput<Water>().WithOutput<OrganicCrystal>().WithCycleTime(6);
        }
    }
}
