using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class MicrocrystallineComponent : BaseItem
    {
        public MicrocrystallineComponent()
        {
            MainRecipe = new Recipe().WithInput<SiliconIngot>(2).WithInput<CopperIngot>().WithCycleTime().WithOutput<MicrocrystallineComponent>().WithCycleTime(2).ProducedInAssembler();
        }
    }
}
