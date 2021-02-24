using DSPCalculator.Items.Components.Materials.Smelter;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Assembler
{
    public class Prism : BaseItem
    {
        public Prism()
        {
            MainRecipe = new Recipe().WithBasicProduction<Glass, Prism>(3, 2, 2).ProducedInAssembler();
        }
    }
}
