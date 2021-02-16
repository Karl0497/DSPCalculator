using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.LiquidAndGas
{
    public class Deuterium : BaseItem
    {
        public Deuterium()
        {
            MainRecipe = new Recipe().WithBasicProduction<Hydrogen, Deuterium>(10, 5, 5);
        }
    }
}
