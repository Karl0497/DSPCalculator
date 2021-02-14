using DSPCalculator.Items.Ores;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class StoneBrick : BaseItem
    {
        public StoneBrick()
        {
            MainRecipe = new Recipe().WithBasicProduction<StoneOre, StoneBrick>(1, 1, 1);
        }
    }
}
