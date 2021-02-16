using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class MagneticCoil : BaseItem
    {
        public MagneticCoil()
        {
            MainRecipe = new Recipe().WithInput<Magnet>(2).WithInput<CopperIngot>(1).WithCycleTime(1).WithOutput<MagneticCoil>(2).ProducedInAssembler();
        }
    }
}
