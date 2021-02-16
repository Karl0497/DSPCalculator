using DSPCalculator.Items.Components.Liquid;
using DSPCalculator.Items.Components.Ores;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSPCalculator.Items.Components.Materials
{
    public class Graphene : BaseItem
    {
        public Graphene()
        {
            MainRecipe = new Recipe().WithInput<SulfuricAcid>(1).WithInput<EnergeticGraphite>(3).WithCycleTime(3).WithOutput<Graphene>(2);
            AlternativeRecipe = new Recipe().WithInput<FireIce>(2).WithOutput<Hydrogen>().WithOutput<Graphene>(2).WithCycleTime(2);
        }
    }
}
