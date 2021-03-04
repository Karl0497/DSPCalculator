using DSPCalculator.Items;
using DSPCalculator.Items.Components;
using Microsoft.VisualBasic.CompilerServices;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using LicenseContext = OfficeOpenXml.LicenseContext;
namespace DSPCalculator
{
    public class Program
    {


        

        

        

        

        public static void Main(string[] args)
        {        
            IEnumerable<Type> allItemTypes = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(assembly => assembly.GetTypes())
                       .Where(type => type.IsSubclassOf(typeof(BaseItem)))
                       .OrderBy(x => x.Name);
      
            foreach (Type type in allItemTypes)
            {
                BaseItem instance = (BaseItem)Activator.CreateInstance(type);
                BaseItem.AllItems.Add(instance);
            }

            ExcelHelper.OpenExcelFile();
            ExcelHelper.GetRequests();
            while (true)
            {
                BaseItem item = BaseItem.ItemsToProcess().FirstOrDefault();
                if (item == null)
                {
                    break;
                }

                item.CalculateProductionChain();

            }

            ExcelHelper.WriteExcelFile();
        }
    }
}
