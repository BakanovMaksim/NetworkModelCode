using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Core.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;

namespace NetworkModelCode.Core.Application
{
    internal class MathModelAnalyzer
    {
        private IReadOnlyList<TechnologicalCondition> TechnologicalConditions { get; }
        private NumberOfClockCyclesCalculator Calculator { get; }

        public MathModelAnalyzer(IReadOnlyList<TechnologicalCondition> technologicalConditions)
        {
            TechnologicalConditions = technologicalConditions;
            Calculator = new NumberOfClockCyclesCalculator(technologicalConditions);
        }

        internal bool CheckCompatibilitySystem()
        {
            var timePossibleMinimums = GetTimePossibleMin();
            var timePossibleMaximums = GetTimePossibleMax();

            for(int k = 0;k<TechnologicalConditions.Count;k++)
            {
                var timePossibleMin = timePossibleMinimums.ElementAtOrDefault(k);
                var timePossibleMax = timePossibleMaximums.ElementAtOrDefault(k);

                if (!(timePossibleMax >= timePossibleMin) ||
                    !((timePossibleMin * TechnologicalConditions[k].ResourceConsumptionRateMin) <= TechnologicalConditions[k].ResourceCapacity))
                {
                    return false;
                }
            }

            return true;
        }

        internal IEnumerable<double> GetTimePossibleMin()
        {
            var minimums = Calculator.CalculateMinimums();

            for (int k = 0;k<TechnologicalConditions.Count;k++)
            {
                var min = minimums.ElementAtOrDefault(k);

                yield return Math.Max(TechnologicalConditions[k].TimeMin, min);
            }
        }

        internal IEnumerable<double> GetTimePossibleMax()
        {
            var maximums = Calculator.CalculateMaximums();

            for(int k = 0;k<TechnologicalConditions.Count;k++)
            {
                var max = maximums.ElementAtOrDefault(k);

                yield return Math.Min(TechnologicalConditions[k].TimeMax, max);
            }
        }
    }
}
