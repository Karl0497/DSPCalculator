using DSPCalculator.Items.Components.Ores;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class CrystalSilicon : BaseItem
    {
        public CrystalSilicon()
        {
            MainRecipe = new Recipe().WithBasicProduction<SiliconIngot, CrystalSilicon>(1, 1, 2);
            AlternativeRecipe = new Recipe().WithBasicProduction<FractalSilicon, CrystalSilicon>(1, 1, 4).ProducedInAssembler();
        }
    }
}
