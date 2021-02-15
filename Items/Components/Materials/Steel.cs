using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class Steel : BaseItem
    {
        public Steel()
        {
            MainRecipe = new Recipe().WithBasicProduction<IronIngot, Steel>(3, 1, 3);
        }
    }
}
