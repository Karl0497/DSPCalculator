using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class CircuitBoard : BaseItem
    {
        public CircuitBoard()
        {
            MainRecipe = new Recipe().WithInput<IronIngot>(2).WithInput<CopperIngot>(1).WithOutput<CircuitBoard>(2).WithCycleTime(1).ProducedInAssembler();
        }
    }
}
