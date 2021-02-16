using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Assembler
{
    public class PlaneFilter : BaseItem
    {
        public PlaneFilter()
        {
            MainRecipe = new Recipe().WithInput<CasimirCrystal>().WithInput<TitaniumGlass>(2).WithOutput<PlaneFilter>().WithCycleTime(12).ProducedInAssembler();
        }
    }
}
