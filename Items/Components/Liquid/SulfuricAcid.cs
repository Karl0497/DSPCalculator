using DSPCalculator.Items.Ores;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Liquid
{
    public class SulfuricAcid : BaseItem
    {
        public SulfuricAcid()
        {
            MainRecipe = new Recipe().WithInput<RefinedOil>(6).WithInput<StoneOre>(8).WithInput<Water>(4).WithOutput<SulfuricAcid>(4).WithCycleTime(6);
        }
    }
}
