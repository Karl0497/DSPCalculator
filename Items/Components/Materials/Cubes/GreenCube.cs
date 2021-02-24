using DSPCalculator.Items.Components.Materials.Assembler;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Cubes
{
    public class GreenCube : BaseItem
    {
        public GreenCube()
        {
            MainRecipe = new Recipe().WithInput<GravitonLens>().WithInput<QuantumChip>().WithOutput<GreenCube>(2).WithCycleTime(24);
        }
    }
}
