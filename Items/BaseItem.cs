using Fractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public bool debug { get { return this.GetType().Name == "CasimirCrystal"; } }
            
        /// <summary>
        /// Max number of assemblers/smelters/etc. for a full belt or products based on the output, assuming 1 product per belt because only maniacs would put all products on the same belt
        /// No overflowing allowed, i.e. if the prod rate is 2 items/s and belt speed is 5 items/s, only 2 structures are allowed
        /// </summary>
        public decimal StructureLimit_Output = 0;

        /// <summary>
        /// Max number of assemblers/smelters/etc. for a full belt or products based on the input, assuming 1 product per belt
        /// </summary>
        /// <returns></returns>
        public decimal StructureLimit_Input = 0;

        private decimal _structureLimit = 0;

        [Description("Production Scale")]
        /// <summary>
        /// Based on structure limit with a 1:1 input/output scale
        /// </summary>
        /// <returns></returns>
        public decimal ProductionScale
        {
            get
            {
                if (StructureLimit == 0)
                {
                    return 0;
                }

                return Math.Ceiling(StructuresNeeded / StructureLimit);
            }

        }

        [Description("Structure Limit")]
        public decimal StructureLimit
        {
            get
            {
                if (_structureLimit == 0 && Recipe != null)
                {
                    _structureLimit = CalculateStructureLimit();
                }

                return _structureLimit;
            }
        }

        // Alternative recipe is usually better
        public Recipe Recipe
        {
            get
            {
                return AlternativeRecipe ?? MainRecipe;
            }
        }


        [Description("Number of structures")]
        public decimal StructuresNeeded
        {
            get
            {
                if (StructureLimit == 0)
                {
                    return 0;
                }

                decimal currentOutputRate = Recipe.OutputProductionRate(GetType());
                decimal numOfStructs = Math.Ceiling(ActualOutput / currentOutputRate);

                return numOfStructs;
            }         
        }

        [Description("Input/Output Scale")]
        public string InputOutputScale
        {
            get
            {
                if (StructureLimit == 0)
                {
                    return "N/A";
                }
                Fraction numerator = new Fraction(StructureLimit_Input);
                Fraction denominator = new Fraction(StructureLimit_Output);
                Fraction fraction = (numerator / denominator).Reduce();

                return $"{fraction.Numerator}:{fraction.Denominator}";
            }
        }

        [Description("Produced in assembler")]
        public bool ProducedInAssembler => Recipe == null ? false : Recipe.IsProducedInAssembler;

        // requested output of an item from the excel sheet
        [Description(GlobalHelper.REQUESTED_OUTPUT)]
        public decimal RequestedOutput;

        // this is used for calculating only so that it doesnt double up values when rerunning the script on the same file
        [Description("Required Output")]
        public decimal RequiredOutput;

        [Description("Actual Output")]
        public decimal ActualOutput;

        public bool IsOutputSatisfied()
        {
            // If current production chain can provide more than needed
            return ActualOutput >= RequiredOutput;
        }

        private void CalculateStructureLimit_Output()
        {
            if (Recipe == null)
            {
                return;
            }

            decimal max = int.MaxValue;
            foreach (ItemToAmount output in Recipe.Output)
            {
                decimal outputRate = Recipe.OutputProductionRate(output.ItemType);
                decimal beltSpeed = GlobalHelper.BeltSpeed;
                max = Math.Min(beltSpeed / outputRate, max);
            }
            StructureLimit_Output = Math.Round(max,2);
        }

        private void CalculateStructureLimit_Input()
        {
            if (Recipe == null)
            {
                return;
            }

            decimal max = int.MaxValue;
            foreach (ItemToAmount input in Recipe.Input)
            {
                decimal inputRate = Recipe.InputProductionRate(input.ItemType);
                decimal beltSpeed = GlobalHelper.BeltSpeed;
                max = Math.Min(beltSpeed / inputRate, max);
            }

            StructureLimit_Input = Math.Round(max, 2);
        }

        /// <summary>
        /// Max number of assemblers/smelters/etc. for a full belt or products based on the input and output
        /// </summary>
        /// <returns></returns>
        private decimal CalculateStructureLimit()
        {
            CalculateStructureLimit_Output();
            CalculateStructureLimit_Input();
            return Math.Min(StructureLimit_Input, StructureLimit_Output);
        }

        public void CalculateProductionChain()
        {
            // Lowest level materials, e.g. ores
            if (Recipe == null)
            {
                ActualOutput = RequiredOutput;
                return;
            }
            decimal currentOutputRate = Recipe.OutputProductionRate(GetType());
            decimal outputRateDelta = RequiredOutput - ActualOutput;
            decimal scale = Math.Ceiling(outputRateDelta / currentOutputRate);

            foreach (ItemToAmount input in Recipe.Input)
            {
                BaseItem item = GlobalHelper.GetItem(input.ItemType);
                item.RequiredOutput += Recipe.InputProductionRate(input.ItemType) * scale;
            }

            foreach (ItemToAmount output in Recipe.Output)
            {
                BaseItem item = GlobalHelper.GetItem(output.ItemType);
                item.ActualOutput += Recipe.OutputProductionRate(output.ItemType) * scale;
            }
        }
    }
}
