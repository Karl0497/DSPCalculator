using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Assembler
{
    public class PhotonCombiner : BaseItem
    {
        public PhotonCombiner()
        {
            MainRecipe = new Recipe().WithInput<Prism>(2).WithInput<CircuitBoard>().WithOutput<PhotonCombiner>().WithCycleTime(3).ProducedInAssembler();
        }
    }
}
