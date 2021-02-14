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
            return AllItems.FirstOrDefault(x => x.GetType() == type);
        }

        public static BaseItem GetItem(string className)
        {
            return AllItems.FirstOrDefault(x => x.GetType().Name == className);
        }

        public static BaseItem GetItem<T>() where T : BaseItem
        {
            return GetItem(typeof(T));
        }

        public static IList<BaseItem> ItemsToProcess()
        {
            return AllItems.Where(x => !x.IsOutputSatisfied()).ToList();
        }

        public static int STARTING_ROW = 1;
        public static int STARTING_COLUMN = 1;
        public static string ITEM = "Item";
        public const string REQUESTED_OUTPUT = "Requested Output";
        public static string FILENAME = "DysonCalculator.xlsx";
        public static string PATH = $@"C:\Users\khoan\Desktop\{FILENAME}"; 
    }
}
