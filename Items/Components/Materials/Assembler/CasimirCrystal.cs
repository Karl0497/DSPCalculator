using DSPCalculator.Items.Components.Ores;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Assembler
{
    public class CasimirCrystal : BaseItem
    {
        public CasimirCrystal()
        {
            MainRecipe = new Recipe().WithInput<TitaniumCrystal>().WithInput<Graphene>(2).WithInput<Hydrogen>(12).WithOutput<CasimirCrystal>().WithCycleTime(4).ProducedInAssembler();
            AlternativeRecipe = new Recipe().WithInput<OpticalGratingCrystal>(6).WithInput<Graphene>(2).WithInput<Hydrogen>(12).WithOutput<CasimirCrystal>().WithCycleTime(4).ProducedInAssembler();
        }
    }
}
