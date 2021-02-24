using DSPCalculator.Items.Components.Materials.Cubes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Assembler
{
    public class SpaceWarper : BaseItem
    {
        public SpaceWarper()
        {
            MainRecipe = new Recipe().WithBasicProduction<GreenCube, SpaceWarper>(1, 8, 10).ProducedInAssembler();
        }
    }
}
