using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components
{
    public class RefinedOil : BaseItem
    {
        public RefinedOil()
        {
            MainRecipe = new Recipe()
                .WithInput<CrudeOil>(2)
                .WithOutput<Hydrogen>(1)
                .WithOutput<RefinedOil>(2)
                .WithCycleTime(4);
        }
    }
}
