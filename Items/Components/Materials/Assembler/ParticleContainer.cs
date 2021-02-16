using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class ParticleContainer : BaseItem
    {
        public ParticleContainer()
        {
            MainRecipe = new Recipe().WithInput<ElectromagneticTurbine>(2).WithInput<CopperIngot>(2).WithInput<Graphene>(2).WithOutput<ParticleContainer>().WithCycleTime(4).ProducedInAssembler();
        }
    }
}
