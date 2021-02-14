using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSPCalculator.Items
{
    public class BaseItem
    {
        public BaseItem()
        {
        }

        public Recipe MainRecipe = null;

        public Recipe AlternativeRecipe = null;


        // Alternative recipe is usually better
        public Recipe Recipe
        {
            get
            {
                return AlternativeRecipe ?? MainRecipe;
            }
        }


        // items per minute
        public decimal RequestedOutput; 
        public decimal ActualOutput;

        public bool IsOutputSatisfied()
        {
            // If current production chain can provide more than needed OR the product is at the lowest level, e.g. Ores
            return ActualOutput >= RequestedOutput || Recipe == null;
        }
        /// <summary>
        /// Max number of assemblers/smelters/etc. for a full belt or products based on the output, assuming 1 product per belt because only maniacs would put all products on the same belt
        /// No overflowing allowed, i.e. if the prod rate is 2 items/s and belt speed is 5 items/s, only 2 structures are allowed
        /// </summary>
        public int MaxProductionStructures_Output()
        {
            if (Recipe == null)
            {
                return 0;
            }

            int max = int.MaxValue;
            foreach (ItemToAmount output in Recipe.Output)
            {
                decimal outputRate = Recipe.OutputProductionRate(output.ItemType);
                decimal beltSpeed = GlobalHelper.BeltSpeed;
                max = (int)Math.Min(Math.Floor(beltSpeed / outputRate), max);
            }

            return max;
        }

        /// <summary>
        /// Max number of assemblers/smelters/etc. for a full belt or products based on the input, assuming 1 product per belt because
        /// </summary>
        /// <returns></returns>
        public int MaxProductionStructures_Input()
        {
            if (Recipe == null)
            {
                return 0;
            }

            int max = int.MaxValue;
            foreach (ItemToAmount input in Recipe.Output)
            {
                decimal inputRate = Recipe.OutputProductionRate(input.ItemType);
                decimal beltSpeed = GlobalHelper.BeltSpeed;
                max = (int)Math.Min(Math.Floor(beltSpeed / inputRate), max);
            }

            return max;
        }

        /// <summary>
        /// Max number of assemblers/smelters/etc. for a full belt or products based on the input and output
        /// </summary>
        /// <returns></returns>
        public int MaxProductionStructures()
        {
            return Math.Min(MaxProductionStructures_Output(), MaxProductionStructures_Input());
        }

        public void CalculateProductionChain()
        {
            decimal currentOutputRate = Recipe.OutputProductionRate(GetType());
            decimal outputRateDelta = RequestedOutput - ActualOutput;
            decimal scale = Math.Ceiling(outputRateDelta / currentOutputRate);

            foreach (ItemToAmount input in Recipe.Input)
            {
                BaseItem item = GlobalHelper.GetItem(input.ItemType);
                item.RequestedOutput += Recipe.InputProductionRate(input.ItemType) * scale;
            }

            foreach (ItemToAmount output in Recipe.Output)
            {
                BaseItem item = GlobalHelper.GetItem(output.ItemType);
                item.ActualOutput += Recipe.OutputProductionRate(output.ItemType) * scale;
            }
        }
    }
}
