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

        public Recipe MainRecipe = null;

        public Recipe AlternativeRecipe = null;

        public bool debug { get { return this.GetType().Name == "ParticleContainer"; } }
            
        /// <summary>
        /// Max number of assemblers/smelters/etc. for a full belt or products based on the output, assuming 1 product per belt because only maniacs would put all products on the same belt
        /// No overflowing allowed, i.e. if the prod rate is 2 items/s and belt speed is 5 items/s, only 2 structures are allowed
        /// </summary>
        public Fraction StructureLimit_Output = 0;

        /// <summary>
        /// Max number of assemblers/smelters/etc. for a full belt or products based on the input, assuming 1 product per belt
        /// </summary>
        /// <returns></returns>
        public Fraction StructureLimit_Input = 0;

        private Fraction _structureLimit = 0;

        [Description("Structure Limit")]
        public decimal StructureLimit
        {
            get
            {
                if (_structureLimit == 0 && Recipe != null)
                {
                    _structureLimit = CalculateStructureLimit();
                }

                return Math.Round(_structureLimit.ToDecimal(), 2);
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
                Fraction numerator = StructureLimit_Input;
                Fraction denominator = StructureLimit_Output;
                Fraction fraction = (numerator / denominator).Reduce();

                return $"{fraction.Numerator}/{fraction.Denominator}";
            }
        }

        [Description("Produced in assembler")]
        public bool ProducedInAssembler => Recipe == null ? false : Recipe.IsProducedInAssembler;

        [Description("Produced in smelter")]
        public bool ProducedInSmelter => Recipe == null ? false : Recipe.IsProducedInSmelter;

        // requested output of an item from the excel sheet
        [Description(GlobalHelper.REQUESTED_OUTPUT)]
        public decimal RequestedOutput;

        // this is used for calculating only so that it doesnt double up values when rerunning the script on the same file
        [Description("Required Output")]
        public decimal RequiredOutput;

        [Description("Actual Output")]
        public decimal ActualOutput;

        // Production rate for a full scale of MaxStructure
        [Description("Production Rate - Full scale")]
        public decimal ProductionRatePerSector => Recipe == null ? 0 : StructureLimit * Recipe.OutputProductionRate(this.GetType());

        [Description("Note - Structures per station")]
        public string Note;
        
        [Description("Location")]
        public string Location;

        private int _tier = 0;

        [Description("Tier")]
        public int Tier
        {
            get
            {
                if (_tier == 0)
                {
                    if (Recipe == null)
                    {
                        return 0;
                    }

                    int min = 0;

                    foreach (var input in Recipe.Input)
                    {
                        min = Math.Max(GetItem(input.ItemType).Tier, min);
                    }

                    _tier = min + 1;
                }

                return _tier;
            }
        }
        public bool IsOutputSatisfied()
        {
            // If current production chain can provide more than needed
            return ActualOutput >= RequiredOutput;
        }

        private void CalculateStructureLimit_Output()
        {
            if (debug)
            {

            }

            if (Recipe == null)
            {
                return;
            }

            Fraction max = int.MaxValue;
            foreach (ItemToAmount output in Recipe.Output)
            {
                decimal outputRate = Recipe.OutputProductionRate(output.ItemType);
                decimal beltSpeed = GlobalHelper.BeltSpeed;
                Fraction fraction = new Fraction(beltSpeed) / new Fraction(outputRate);
                if (fraction < max)
                {
                    max = fraction;
                }
            }
            StructureLimit_Output = max;
        }

        private void CalculateStructureLimit_Input()
        {
            if (Recipe == null)
            {
                return;
            }

            Fraction max = int.MaxValue;
            foreach (ItemToAmount input in Recipe.Input)
            {
                decimal inputRate = Recipe.InputProductionRate(input.ItemType);
                decimal beltSpeed = GlobalHelper.BeltSpeed;
                Fraction fraction = new Fraction(beltSpeed) / new Fraction(inputRate);
                if (fraction < max)
                {
                    max = fraction;
                }
            }

            StructureLimit_Input = max;
        }

        /// <summary>
        /// Max number of assemblers/smelters/etc. for a full belt or products based on the input and output
        /// </summary>
        /// <returns></returns>
        private Fraction CalculateStructureLimit()
        {
            CalculateStructureLimit_Output();
            CalculateStructureLimit_Input();
            if (StructureLimit_Input < StructureLimit_Output)
            {
                return StructureLimit_Input;
            }

            return StructureLimit_Output;
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
                BaseItem item = BaseItem.GetItem(input.ItemType);
                item.RequiredOutput += Recipe.InputProductionRate(input.ItemType) * scale;
            }

            foreach (ItemToAmount output in Recipe.Output)
            {
                BaseItem item = BaseItem.GetItem(output.ItemType);
                item.ActualOutput += Recipe.OutputProductionRate(output.ItemType) * scale;
            }
        }
    }
}
