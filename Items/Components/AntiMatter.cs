using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.LiquidAndGas
{
    public class AntiMatter : BaseItem
    {
        public AntiMatter()
        {
            MainRecipe = new Recipe().WithInput<CriticalPhoton>(2).WithOutput<AntiMatter>(2).WithOutput<Hydrogen>(2).WithCycleTime(2);
        }
    }
}
