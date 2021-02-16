using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class ElectromagneticTurbine : BaseItem
    {
        public ElectromagneticTurbine()
        {
            MainRecipe = new Recipe().WithInput<ElectricMotor>(2).WithInput<MagneticCoil>(2).WithOutput<ElectromagneticTurbine>().WithCycleTime(2).ProducedInAssembler();
        }
    }
}
