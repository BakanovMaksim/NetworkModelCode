using NetworkModelCode.Core.Domain.Entities;

using System;

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

        public TechnologicalConditionBuilder SetTime(int time)
        {
            TechnologicalCondition.Time = time;
            return this;
        }

        public TechnologicalConditionBuilder SetResource(double capacity, double consumptionRateMin, double consumptionRateMax)
        {
            TechnologicalCondition.ResourceCapacity = capacity;
            TechnologicalCondition.ResourceConsumptionMin = consumptionRateMin;
            TechnologicalCondition.ResourceConsumptionMax = consumptionRateMax;

            return this;
        }

        public TechnologicalCondition Build()
        {
            return TechnologicalCondition;
        }
    }
}
