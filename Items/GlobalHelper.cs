using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSPCalculator.Items
{
    public static class GlobalHelper
    {
        public static decimal AssemblerSpeedMultiplier = 1; // Mk. 1 = 0.75; Mk. 2 = 1; Mk.3 = 1.5

        public static decimal OrePerSecondPerNode = 36;

        public static int BeltSpeed = 30 * 60; // 30 items per second

        public static IList<BaseItem> AllItems = new List<BaseItem>();

        public static BaseItem GetItem(Type type)
        {
            return AllItems.First(x => x.GetType() == type);
        }

        public static BaseItem GetItem<T>() where T : BaseItem
        {
            return GetItem(typeof(T));
        }

        public static IList<BaseItem> ItemsToProcess()
        {
            return AllItems.Where(x => !x.IsOutputSatisfied()).ToList();
        }

        public static void Request<T>(int amount) where T : BaseItem
        {
            GetItem<T>().RequestedOutput += amount;
        }
    }
}
