using NetworkModelCode.Core.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("NetworkModelCode.Tests")]
namespace NetworkModelCode.Core.Application.Calculators
{
    internal class NumberOfClockCyclesCalculator
    {
        private IEnumerable<TechnologicalCondition> TechnologicalConditions { get; }

        internal NumberOfClockCyclesCalculator(IEnumerable<TechnologicalCondition> technologicalConditions)
        {
            TechnologicalConditions = technologicalConditions;
        }

        internal IEnumerable<double> CalculateMinimums()
        {
            foreach(var item in TechnologicalConditions)
            {
                if (item.ResourceConsumptionRateMax == 0)
                {
                    yield return 0;
                    continue;
                }

                var value = Math.Round(item.ResourceCapacity / item.ResourceConsumptionRateMax, 3);

                if ((item.ResourceCapacity % item.ResourceConsumptionRateMax) == 0)
                {
                    yield return value;
                }
                else
                {
                    yield return Math.Truncate(value) + 1;
                }
            }
        }

        internal IEnumerable<double> CalculateMaximums()
        {
            foreach(var item in TechnologicalConditions)
            {
                if(item.ResourceConsumptionRateMin == 0)
                {
                    yield return item.ResourceConsumptionRateMax;
                    continue;
                }

                var value = Math.Round(item.ResourceCapacity / item.ResourceConsumptionRateMin, 3);

                if((item.ResourceCapacity % item.ResourceConsumptionRateMin) == 0)
                {
                    yield return value;
                }
                else
                {
                    yield return Math.Truncate(value) + 1;
                }
            }
        }
    }
}
