using DSPCalculator.Items.Components.Ores;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Smelter
{
    public class Glass : BaseItem
    {
        public Glass()
        {
            MainRecipe = new Recipe().WithBasicProduction<Stone, Glass>(2, 1, 2).ProducedInSmelter();
        }
    }
}
