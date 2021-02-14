using DSPCalculator.Items.Components.Liquid;
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
        }
    }
}
