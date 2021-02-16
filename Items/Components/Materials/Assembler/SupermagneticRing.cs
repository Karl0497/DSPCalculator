using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Assembler
{
    public class SupermagneticRing : BaseItem
    {
        public SupermagneticRing()
        {
            MainRecipe = new Recipe().WithInput<ElectromagneticTurbine>(2).WithInput<Magnet>(3).WithInput<EnergeticGraphite>().WithOutput<SupermagneticRing>().WithCycleTime(3).ProducedInAssembler();
        }
    }
}
