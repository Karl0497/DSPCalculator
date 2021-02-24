using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Assembler
{
    public class AnnihilationConstraintSphere : BaseItem
    {
        public AnnihilationConstraintSphere()
        {
            MainRecipe = new Recipe().WithInput<ParticleContainer>().WithInput<Processor>().WithOutput<AnnihilationConstraintSphere>().WithCycleTime(20).ProducedInAssembler();
        }
    }
}
