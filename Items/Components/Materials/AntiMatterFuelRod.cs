using DSPCalculator.Items.Components.Ingots;
using DSPCalculator.Items.Components.LiquidAndGas;
using DSPCalculator.Items.Components.Materials.Assembler;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class AntiMatterFuelRod : BaseItem
    {
        public AntiMatterFuelRod()
        {
            MainRecipe = new Recipe().WithInput<AntiMatter>(10).WithInput<Hydrogen>(10).WithInput<AnnihilationConstraintSphere>().WithInput<TitaniumAlloy>().WithOutput<AntiMatterFuelRod>().WithCycleTime(12);
        }
    }
}
