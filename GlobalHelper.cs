using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSPCalculator.Items
{
    public static class GlobalHelper
    {
        public static decimal AssemblerSpeedMultiplier = 1.5m; // Mk. 1 = 0.75; Mk. 2 = 1; Mk.3 = 1.5

        public static decimal OrePerSecondPerNode = 36;

        public static int BeltSpeed = 30 * 60; // 30 items per second




        public static decimal WARP_SPEED = 5; // LY/s
        public static decimal AVERAGE_DISTANCE = 50; // LYs between planets
        public static decimal VESSEL_CAPACITY = 1000; // LYs between planets
        public static int STARTING_ROW = 1;
        public static int STARTING_COLUMN = 1;
        public static string ITEM = "Item";
        public const string REQUESTED_OUTPUT = "Requested Output";
        public static string FILENAME = "DysonCalculator.xlsx";
        public static string PATH = $@"C:\Users\khoan\Desktop\{FILENAME}"; 
    }
}
