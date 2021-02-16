using DSPCalculator.Items.Components.Materials.Smelter;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Assembler
{
    public class TitaniumGlass : BaseItem
    {
        public TitaniumGlass()
        {
            MainRecipe = new Recipe().WithInput<Glass>(2).WithInput<TitaniumIngot>(2).WithInput<Water>(2).WithOutput<TitaniumGlass>(2).WithCycleTime(5).ProducedInAssembler();
        }
    }
}
