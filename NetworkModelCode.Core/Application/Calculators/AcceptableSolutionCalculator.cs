using NetworkModelCode.Core.Domain.Entities;

using System.Collections.Generic;
using System.Linq;

namespace NetworkModelCode.Core.Application.Calculators
{
    public class AcceptableSolutionCalculator
    {
        private IReadOnlyList<TechnologicalCondition> TechnologicalConditions { get; }
        private IReadOnlyList<TimeCharacteristic> TimeCharacteristics { get; }
        private MathModelAnalyzer Analyzer { get; }

        public AcceptableSolutionCalculator(
            IReadOnlyList<TechnologicalCondition> technologicalConditions,
            IReadOnlyList<TimeCharacteristic> timeCharacteristics)
        {
            TechnologicalConditions = technologicalConditions;
            TimeCharacteristics = timeCharacteristics; 
            Analyzer = new MathModelAnalyzer(technologicalConditions);
        }

        public void CalculateLimitingTimeRun()
        {
            var count = TechnologicalConditions.Count;

            for (int k = 0; k < count; k++)
            {
                if (TechnologicalConditions[k].TimeMin <= (TimeCharacteristics[k].EarlyFinish - TimeCharacteristics[k].EarlyStart + 1)
                    && TechnologicalConditions[k].TimeMax >= (TimeCharacteristics[k].EarlyFinish - TimeCharacteristics[k].EarlyStart + 1))
                {

                }
            }
        }

        public void CalculateLimitingFullUseResources()
        {
            var count = TechnologicalConditions.Count;

            for(int k = 0;k<count;k++)
            {
                if(TechnologicalConditions[k].ResourceConsumptionRates.Sum() == TechnologicalConditions[k].ResourceCapacity)
                {

                }
            }
        }
    }
}
