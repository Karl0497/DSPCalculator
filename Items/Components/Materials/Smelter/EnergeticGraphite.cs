using DSPCalculator.Items.Ores;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class EnergeticGraphite : BaseItem
    {
        public EnergeticGraphite()
        {
            MainRecipe = new Recipe().WithBasicProduction<CoalOre, EnergeticGraphite>(2, 1, 2).ProducedInSmelter();
        }
    }
}
