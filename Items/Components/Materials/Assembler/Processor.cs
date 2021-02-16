using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class Processor : BaseItem
    {
        public Processor()
        {
            MainRecipe = new Recipe().WithInput<CircuitBoard>(2).WithInput<MicrocrystallineComponent>(2).WithOutput<Processor>().WithCycleTime(3).ProducedInAssembler();
        }
    }
}
