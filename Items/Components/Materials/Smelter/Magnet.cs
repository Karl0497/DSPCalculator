using DSPCalculator.Items.Ores;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class Magnet : BaseItem
    {
        public Magnet()
        {
            MainRecipe = new Recipe().WithBasicProduction<IronOre, Magnet>(1, 1, 1.5).ProducedInSmelter();
        }
    }
}
