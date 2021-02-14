using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components
{
    public class RefinedOil : BaseItem
    {
        public RefinedOil()
        {
            MainRecipe = GlobalHelper.GetItem<Hydrogen>().MainRecipe;
        }
    }
}
