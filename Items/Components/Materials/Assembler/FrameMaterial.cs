using DSPCalculator.Items.Components.Ingots;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Assembler
{
    public class FrameMaterial : BaseItem
    {
        public FrameMaterial()
        {
            MainRecipe = new Recipe().WithInput<CarbonNanotube>(4).WithInput<TitaniumAlloy>().WithInput<SiliconIngot>().WithOutput<FrameMaterial>().WithCycleTime(6).ProducedInAssembler();
        }
    }
}
