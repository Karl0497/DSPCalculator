using DSPCalculator.Items.Components.Ingots;
using DSPCalculator.Items.Components.LiquidAndGas;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Assembler
{
    public class DeuteronFuelRod : BaseItem
    {
        public DeuteronFuelRod()
        {
            MainRecipe = new Recipe().WithInput<TitaniumAlloy>().WithInput<SupermagneticRing>().WithInput<Deuterium>(10).WithCycleTime(6).WithOutput<DeuteronFuelRod>().ProducedInAssembler();
        }
    }
}
