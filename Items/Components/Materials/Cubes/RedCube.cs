using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Cubes
{
    public class RedCube : BaseItem
    {
        public RedCube()
        {
            MainRecipe = new Recipe().WithInput<EnergeticGraphite>(2).WithInput<Hydrogen>(2).WithOutput<RedCube>(1).WithCycleTime();
        }
    }
}
