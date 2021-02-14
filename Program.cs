using DSPCalculator.Items;
using DSPCalculator.Items.Components;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DSPCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Type> allItemTypes = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(assembly => assembly.GetTypes())
                       .Where(type => type.IsSubclassOf(typeof(BaseItem)));

            foreach (Type type in allItemTypes)
            {
                BaseItem instance = (BaseItem)Activator.CreateInstance(type);
                GlobalHelper.AllItems.Add(instance);
            }

            // Request stuff here
            GlobalHelper.Request<RefinedOil>(100);

            while (true)
            {
                BaseItem item = GlobalHelper.ItemsToProcess().FirstOrDefault();
                if (item == null)
                {
                    break;
                }

                item.CalculateProductionChain();

            }
        }
    }
}
