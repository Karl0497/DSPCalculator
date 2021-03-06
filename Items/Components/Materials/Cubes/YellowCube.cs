﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Cubes
{
    public class YellowCube : BaseItem
    {
        public YellowCube()
        {
            MainRecipe = new Recipe().WithInput<TitaniumCrystal>().WithInput<Diamond>().WithOutput<YellowCube>().WithCycleTime();
        }
    }
}
