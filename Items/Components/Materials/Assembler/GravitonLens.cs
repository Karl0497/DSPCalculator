using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class GravitonLens : BaseItem
    {
        public GravitonLens()
        {
            MainRecipe = new Recipe().WithInput<Diamond>(4).WithInput<StrangeMatter>().WithOutput<GravitonLens>().WithCycleTime(6).ProducedInAssembler();
        }
    }
}
