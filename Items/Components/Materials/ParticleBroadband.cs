using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class ParticleBroadband : BaseItem
    {
        public ParticleBroadband()
        {
            MainRecipe = new Recipe().WithInput<CarbonNanotube>(2).WithInput<CrystalSilicon>(2).WithInput<Plastic>().WithOutput<ParticleBroadband>().WithCycleTime(8).ProducedInAssembler();
        }
    }
}
