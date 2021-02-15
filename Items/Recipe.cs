using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSPCalculator.Items
{
    public class ItemToAmount
    {
        public ItemToAmount(Type type, int amount)
        {
            ItemType = type;
            Amount = amount;
        }

        public Type ItemType;
        public int Amount;
    }

    public class Recipe
    {
        public IList<ItemToAmount> Input;
        public IList<ItemToAmount> Output;

        public Recipe()
        {
            Input = new List<ItemToAmount>();
            Output = new List<ItemToAmount>();
        }

        /// <summary>
        /// Real production rate (items/min), taken into account the assembler speed
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public decimal OutputProductionRate(Type type)
        {
            decimal multipler = IsProducedInAssembler ? GlobalHelper.AssemblerSpeedMultiplier : 1;

            int itemsPerSecond = Output.First(x => x.ItemType == type).Amount;



            return (decimal)itemsPerSecond * 60 * multipler / CycleTime;

        }

        /// <summary>
        /// Real production rate (items/min), taken into account the assembler speed
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public decimal InputProductionRate(Type type)
        {
            decimal multipler = IsProducedInAssembler ? GlobalHelper.AssemblerSpeedMultiplier : 1;

            int itemsPerSecond = Input.First(x => x.ItemType == type).Amount;



            return (decimal)itemsPerSecond * 60 * multipler / CycleTime ;

        }

        public decimal CycleTime;

        public bool IsProducedInAssembler;

        public Recipe WithInput<T>(int amount = 1) where T : BaseItem
        {
            Input.Add(new ItemToAmount(typeof(T), amount));

            return this;
        }

        public Recipe WithOutput<T>(int amount = 1) where T : BaseItem
        {
            Output.Add(new ItemToAmount(typeof(T), amount));

            return this;
        }

        public Recipe WithCycleTime(double sec = 1)
        {
            CycleTime = (decimal)sec;

            return this;
        }


        public Recipe ProducedInAssembler()
        {
            IsProducedInAssembler = true;

            return this;
        }

        public Recipe WithBasicProduction<T1, T2>(int input, int output, double sec) where T1 : BaseItem where T2 : BaseItem
        {
            return WithInput<T1>(input).WithOutput<T2>(output).WithCycleTime(sec);
        }
    }
}
