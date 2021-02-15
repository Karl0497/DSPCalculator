using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Cubes
{
    public class BlueCube : BaseItem
    {
        public BlueCube()
        {
            MainRecipe = new Recipe().WithInput<MagneticCoil>(1).WithInput<CircuitBoard>(1).WithOutput<BlueCube>(1).WithCycleTime(3);
        }
    }
}
