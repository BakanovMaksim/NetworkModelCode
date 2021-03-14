using NetworkModelCode.Core.Domain.Entities;

using System.Collections.Generic;
using System.Linq;

namespace NetworkModelCode.Core.Application.Calculators
{
    public class NetworkEventCalculator
    {
        private IReadOnlyList<TechnologicalCondition> TechnologicalConditions { get; set; }

        public IEnumerable<NetworkEvent> Calculate(IReadOnlyList<TechnologicalCondition> technologicalConditions)
        {
            TechnologicalConditions = technologicalConditions;

            var earlyCompletionDate = CalculateEarlyCompletionDate().ToList();
            var lateCompletionDate = CalculateLateCompletionDate(earlyCompletionDate).ToList();
            var timeReserveCompletionDate = CalculateTimeReserveCompletionDate(earlyCompletionDate, lateCompletionDate).ToList();

            for (int k = 0; k < earlyCompletionDate.Count; k++)
            {
                yield return new NetworkEvent
                {
                    EarlyCompletionDate = earlyCompletionDate[k],
                    LateCompletionDate = lateCompletionDate[k],
                    TimeReserveCompletionDate = timeReserveCompletionDate[k]
                };
            }
        }

        public IEnumerable<int> CalculateEarlyCompletionDate()
        {
            var eventCount = TechnologicalConditions.LastOrDefault().CodeJ;
            var earlys = new List<int>(eventCount);

            for (int k = 1; k < eventCount + 1; k++)
            {
                if (k == 1)
                {
                    earlys.Add(0);
                    continue;
                }

                var works = new List<TechnologicalCondition>();
                foreach (var tecnologicalCondition in TechnologicalConditions)
                {
                    if (k == tecnologicalCondition.CodeJ)
                        works.Add(tecnologicalCondition);
                }

                var max = works.Max(p => p.Time + earlys[p.CodeI - 1]);
                earlys.Add(max);
            }

            return earlys;
        }

        public IEnumerable<int> CalculateLateCompletionDate(IEnumerable<int> earlys)
        {
            var eventCount = TechnologicalConditions.LastOrDefault().CodeJ;
            var lates = new List<int>(eventCount);

            for (int k = eventCount; k > 0; k--)
            {
                if (k == eventCount)
                {
                    lates.Add(earlys.LastOrDefault());
                    continue;
                }

                var works = new List<TechnologicalCondition>();
                foreach (var technologicalCondition in TechnologicalConditions)
                {
                    if (k == technologicalCondition.CodeI)
                        works.Add(technologicalCondition);
                }

                var min = works.Min(p => lates[eventCount - p.CodeJ] - p.Time);
                lates.Add(min);
            }

            lates.Reverse();
            return lates;
        }

        public IEnumerable<int> CalculateTimeReserveCompletionDate(IReadOnlyList<int> earlys, IReadOnlyList<int> lates)
        {
            for (int k = 0; k < earlys.Count; k++)
            {
                yield return lates[k] - earlys[k];
            }
        }
    }
}
