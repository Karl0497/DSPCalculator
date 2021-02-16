using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class Gear : BaseItem
    {
        public Gear()
        {
            MainRecipe = new Recipe().WithBasicProduction<IronIngot, Gear>(1, 1, 1).ProducedInAssembler();
        }
    }
}
