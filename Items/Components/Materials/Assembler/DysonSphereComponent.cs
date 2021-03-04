using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Assembler
{
    public class DysonSphereComponent : BaseItem
    {
        public DysonSphereComponent()
        {
            MainRecipe = new Recipe().WithInput<FrameMaterial>(3).WithInput<SolarSail>(3).WithInput<Processor>(3).WithOutput<DysonSphereComponent>().WithCycleTime(8).ProducedInAssembler();
        }
    }
}
