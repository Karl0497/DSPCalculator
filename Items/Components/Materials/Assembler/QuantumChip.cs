using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials.Assembler
{
    public class QuantumChip : BaseItem
    {
        public QuantumChip()
        {
            MainRecipe = new Recipe().WithInput<Processor>(2).WithInput<PlaneFilter>(2).WithOutput<QuantumChip>().WithCycleTime(6).ProducedInAssembler();
        }
    }
}
