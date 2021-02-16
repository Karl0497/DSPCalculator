using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Cubes
{
    public class WhiteCube : BaseItem
    {
        public WhiteCube()
        {
            MainRecipe = new Recipe().WithInput<BlueCube>().WithInput<RedCube>().WithInput<YellowCube>().WithInput<PurpleCube>().WithInput<GreenCube>().WithOutput<WhiteCube>().WithCycleTime(15);  
        }
    }
}
