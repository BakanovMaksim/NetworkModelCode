using NetworkModelCode.Core.Domain.Entities;

using System;
using System.Collections.Generic;

namespace NetworkModelCode.Core.Domain.Builders
{
    public sealed class TechnologicalConditionBuilder
    {
        private TechnologicalCondition TechnologicalCondition { get; }

        public TechnologicalConditionBuilder()
        {
            TechnologicalCondition = new();
        }

        public TechnologicalConditionBuilder SetTitle(string title)
        {
            TechnologicalCondition.Title = title;
            return this;
        }

        public TechnologicalConditionBuilder SetCode(int i, int j)
        {
            TechnologicalCondition.CodeI = i;
            TechnologicalCondition.CodeJ = j;
            return this;
        }

        public TechnologicalConditionBuilder SetTime(double timeMin, double timeMax)
        {
            TechnologicalCondition.TimeMin = timeMin;
            TechnologicalCondition.TimeMax = timeMax;
            TechnologicalCondition.Time = (int)Math.Round((((3 * timeMin) + (2 * timeMax)) / 5) - 0.1);
            return this;
        }

        public TechnologicalConditionBuilder SetResource(double capacity, double consumptionRateMin, double consumptionRateMax)
        {
            TechnologicalCondition.ResourceCapacity = capacity;
            TechnologicalCondition.ResourceConsumptionRateMin = consumptionRateMin;
            TechnologicalCondition.ResourceConsumptionRateMax = consumptionRateMax;

            var consumptionRates = new List<double>();
            for(int k = 1;k <= TechnologicalCondition.Time;k++)
            {
                consumptionRates.Add(capacity / k);
            }

            TechnologicalCondition.ResourceConsumptionRates = consumptionRates;

            return this;
        }

        public TechnologicalCondition Build()
        {
            return TechnologicalCondition;
        }
    }
}
