using NetworkModelCode.Core.Domain.Entities;

using System.Linq;
using System.Collections.Generic;

namespace NetworkModelCode.Core.Application.Calculators
{
    public class EventCalculator
    {
        private IReadOnlyList<TechnologicalCondition> TechnologicalConditions { get; set; }

        public void Calculate(IReadOnlyList<TechnologicalCondition> technologicalConditions)
        {
            TechnologicalConditions = technologicalConditions;
        }

        public IEnumerable<int> CalculateEarlyCompletionDate()
        {
            var eventCount = TechnologicalConditions.LastOrDefault().CodeJ;
            var earlyCompletionDate = new List<int>(eventCount);

            for(int k = 0;k < eventCount;k++)
            {
                if (k == 0) earlyCompletionDate.Add(0);

                var works = new List<TechnologicalCondition>();
                for(int j = 0;j<TechnologicalConditions.Count;k++)
                {
                    if(k == TechnologicalConditions[j].CodeJ)
                    {
                        works.Add(TechnologicalConditions[k]);
                    }
                }

                var value = works.Max(p => p.Time + earlyCompletionDate[p.CodeI - 1]);
                earlyCompletionDate.Add(value);
            }

            return earlyCompletionDate;
        }
    }
}
