using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Cubes
{
    public class PurpleCube : BaseItem
    {
        public PurpleCube()
        {
            MainRecipe = new Recipe().WithInput<Processor>(2).WithInput<ParticleBroadband>().WithOutput<PurpleCube>().WithCycleTime(10);
        }
    }
}
