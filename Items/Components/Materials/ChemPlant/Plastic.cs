using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class Plastic : BaseItem
    {
        public Plastic()
        {
            MainRecipe = new Recipe().WithInput<EnergeticGraphite>(1).WithInput<RefinedOil>(2).WithOutput<Plastic>(1).WithCycleTime(3);
        }
    }
}
