using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Assembler
{
    public class SolarSail : BaseItem
    {
        public SolarSail()
        {
            MainRecipe = new Recipe().WithInput<Graphene>().WithInput<PhotonCombiner>().WithOutput<SolarSail>(2).WithCycleTime(4).ProducedInAssembler();
        }
    }
}
