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
        static ExcelWorksheet Worksheet; 
        static ExcelPackage Package;

        private static int GetLastNonEmptyColumnIndex()
        {
            var row = Worksheet.Cells[$"{GlobalHelper.STARTING_COLUMN}:{GlobalHelper.STARTING_COLUMN}"];
            if (row.Count() == 0)
            {
                return GlobalHelper.STARTING_COLUMN;
            }
            return row.Last().End.Column;
        }

        public static int FindRowIndex(string itemName)
        {
            var itemNameColumn = FindColumnIndex(GlobalHelper.ITEM);
            int row = GlobalHelper.STARTING_ROW + 1;

            while (true)
            {
                ExcelRange urlCell = Worksheet.Cells[row, itemNameColumn];
                var name = urlCell.Value;

                if (name == null || name.ToString() == itemName || name.ToString().Trim() == "")
                {
                    break;
                }
                row++;
            }
            return row;
        }

        public static void GetRequests()
        {
            var itemNameColumn = AddColumnIfNotExists(GlobalHelper.ITEM);
            int requestColumn = AddColumnIfNotExists(GlobalHelper.REQUESTED_OUTPUT);
            int row = GlobalHelper.STARTING_ROW + 1;

            while (true)
            {      
                ExcelRange requestCell = Worksheet.Cells[row, requestColumn];
                ExcelRange nameCell = Worksheet.Cells[row, itemNameColumn];

                if (nameCell.Value == null)
                {
                    break;
                }

                BaseItem item = BaseItem.GetItem(nameCell.Value.ToString());
                if (item == null || requestCell.Value == null)
                {
                    row++;
                    continue;
                }

                
                item.RequestedOutput += Convert.ToDecimal(requestCell.Value);
                item.RequiredOutput = item.RequestedOutput;
                row++;
            }
        }

        private static int InsertEmptyColumn()
        {
            int emptyColumn = FindColumnIndex(null);

            if (emptyColumn > 0)
            {
                return emptyColumn;
            }

            emptyColumn = GetLastNonEmptyColumnIndex() + 1;
            Worksheet.InsertColumn(emptyColumn, 1);

            return emptyColumn;
        }
        public static int FindColumnIndex(string name)
        {
            int lastNonEmptyColumn = GetLastNonEmptyColumnIndex();
            int column = GlobalHelper.STARTING_COLUMN;

            while (column <= lastNonEmptyColumn)
            {
                if (Worksheet.Cells[GlobalHelper.STARTING_ROW, column].Value?.ToString() == name)
                {
                    return column;
                }

                column++;
            }

            return 0;
        }

        private static int AddColumnIfNotExists(string desc)
        {
            int column = FindColumnIndex(desc);

            if (column == 0)
            {
                column = InsertEmptyColumn();
                Worksheet.Cells[GlobalHelper.STARTING_ROW, column].Value = desc;
            }

            return column;
        }

        public static void OpenExcelFile()
        {
            Process[] excelProcesses = Process.GetProcessesByName("excel");
            excelProcesses.FirstOrDefault(x => x.MainWindowTitle.Contains(GlobalHelper.FILENAME))?.Kill();

            FileInfo fileInfo = new FileInfo(GlobalHelper.PATH);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            Package = new ExcelPackage(fileInfo);
            Worksheet = Package.Workbook.Worksheets.FirstOrDefault();
        }

        public static void WriteExcelFile()
        {
            foreach (var item in BaseItem.AllItems)
            {
                int row = FindRowIndex(item.GetType().Name);
                Worksheet.Cells[row, FindColumnIndex(GlobalHelper.ITEM)].Value = item.GetType().Name;
                IList<FieldInfo> fields = item.GetType().GetFields().ToList();
                IList<PropertyInfo> properties = item.GetType().GetProperties().ToList();
                IList<MemberInfo> members = fields.Cast<MemberInfo>().Concat(properties).ToList();
                foreach (MemberInfo memberInfo in members)
                {
                    DescriptionAttribute descriptionAttribute = (DescriptionAttribute)memberInfo.GetCustomAttribute(typeof(DescriptionAttribute), false);

                    if (descriptionAttribute == null)
                    {
                        continue;
                    }

                    int column = AddColumnIfNotExists(descriptionAttribute.Description);
                    object value = null;
                    switch (memberInfo.MemberType)
                    {
                        case MemberTypes.Field:
                            value = ((FieldInfo)memberInfo).GetValue(item);
                            break;
                        case MemberTypes.Property:
                            value = ((PropertyInfo)memberInfo).GetValue(item);
                            break;
                    }


                    if (memberInfo.ReflectedType == typeof(decimal))
                    {
                        value = Math.Round((decimal)value, 2);
                    }

                    Worksheet.Cells[row, column].Value = value;
                    Worksheet.Cells[Worksheet.Dimension.Address].AutoFitColumns();
                    Package.Save();
                }
            }

            Process p = new Process();
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = GlobalHelper.PATH;
            p.Start();
        }

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

            OpenExcelFile();
            GetRequests();
            while (true)
            {
                BaseItem item = BaseItem.ItemsToProcess().FirstOrDefault();
                if (item == null)
                {
                    break;
                }

                item.CalculateProductionChain();

            }
            
            WriteExcelFile();
        }
    }
}
