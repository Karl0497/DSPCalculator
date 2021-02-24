using DSPCalculator.Items.Components.Ores;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class Diamond : BaseItem
    {
        public Diamond()
        {
            MainRecipe = new Recipe().WithBasicProduction<EnergeticGraphite, Diamond>(1, 1, 2).ProducedInSmelter();
            AlternativeRecipe = new Recipe().WithBasicProduction<KimberliteOre, Diamond>(1, 1, 2).ProducedInSmelter();
        }
    }
}
