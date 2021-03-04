using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Assembler
{
    public class Rocket : BaseItem
    {
        public Rocket()
        {
            MainRecipe = new Recipe().WithInput<DysonSphereComponent>(2).WithInput<DeuteronFuelRod>(2).WithInput<QuantumChip>(2).WithOutput<Rocket>().WithCycleTime(6).ProducedInAssembler();
        }
    }
}
