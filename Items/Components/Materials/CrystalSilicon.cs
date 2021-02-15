using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class CrystalSilicon : BaseItem
    {
        public CrystalSilicon()
        {
            MainRecipe = new Recipe().WithBasicProduction<Silicon, CrystalSilicon>(1, 1, 2);
        }
    }
}
