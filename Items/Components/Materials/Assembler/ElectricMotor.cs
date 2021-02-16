using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class ElectricMotor : BaseItem
    {
        public ElectricMotor()
        {
            MainRecipe = new Recipe().WithInput<IronIngot>(2).WithInput<Gear>().WithInput<MagneticCoil>().WithOutput<ElectricMotor>().WithCycleTime(2).ProducedInAssembler();
        }
    }
}
