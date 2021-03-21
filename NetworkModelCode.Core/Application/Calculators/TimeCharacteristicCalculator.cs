using NetworkModelCode.Core.Domain.Builders;
using NetworkModelCode.Core.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;

namespace NetworkModelCode.Core.Application.Calculators
{
    public class TimeCharacteristicCalculator
    {
        private IReadOnlyList<TechnologicalCondition> _technologicalConditions;
        private IReadOnlyList<NetworkEvent> _networkEvents;

        public TimeCharacteristicCalculator(IReadOnlyList<TechnologicalCondition> technologicalConditions)
        {
            if (technologicalConditions == null)
            {
                throw new ArgumentNullException("Передана пустая ссылка.", nameof(technologicalConditions));
            }

            _technologicalConditions = technologicalConditions;
            _networkEvents = NetworkEventCalculator
                .Calculate(technologicalConditions)
                .ToList();
        }

        public IEnumerable<TimeCharacteristic> Calculate()
        {
            var earlyStarts = CalculateEarlyStarts().ToList();
            var earlyFinishes = CalculateEarlyFinishes().ToList();
            var lateStarts = CalculateLateStarts().ToList();
            var lateFinishes = CalculateLateFinishes().ToList();
            var reserveFullTimes = CalculateReserveFullTimes(lateFinishes, earlyFinishes).ToList();
            var reserveFreeTimes = CalculateReserveFreeTimes(lateStarts, earlyStarts).ToList();

            for (int k = 0; k < _technologicalConditions.Count; k++)
            {
                yield return
                    new TimeCharacteristicBuilder()
                    .SetEarly(earlyStarts[k], earlyFinishes[k])
                    .SetLate(lateStarts[k], lateFinishes[k])
                    .SetReserve(reserveFullTimes[k], reserveFreeTimes[k])
                    .Build();
            }
        }

        private IEnumerable<int> CalculateEarlyStarts()
        {
            foreach (var technologicalCondition in _technologicalConditions)
            {
                var networkEvent = _networkEvents.ElementAtOrDefault(technologicalCondition.CodeI - 1);

                yield return networkEvent.EarlyCompletionDate;
            }
        }

        private IEnumerable<int> CalculateEarlyFinishes()
        {
            foreach (var technologicalCondition in _technologicalConditions)
            {
                var networkEvent = _networkEvents.ElementAtOrDefault(technologicalCondition.CodeI - 1);

                yield return networkEvent.EarlyCompletionDate + technologicalCondition.Time;
            }
        }

        private IEnumerable<int> CalculateLateStarts()
        {
            foreach (var technologicalCondition in _technologicalConditions)
            {
                var networkEvent = _networkEvents.ElementAtOrDefault(technologicalCondition.CodeJ - 1);

                yield return networkEvent.LateCompletionDate - technologicalCondition.Time;
            }
        }

        private IEnumerable<int> CalculateLateFinishes()
        {
            foreach (var technologicalCondition in _technologicalConditions)
            {
                var networkEvent = _networkEvents.ElementAtOrDefault(technologicalCondition.CodeJ - 1);

                yield return networkEvent.LateCompletionDate;
            }
        }

        private IEnumerable<int> CalculateReserveFullTimes(IReadOnlyList<int> lateFinishes, IReadOnlyList<int> earlyFinishes)
        {
            for (int k = 0; k < _technologicalConditions.Count; k++)
            {
                yield return lateFinishes[k] - earlyFinishes[k];
            }
        }

        private IEnumerable<int> CalculateReserveFreeTimes(IReadOnlyList<int> lateStarts, IReadOnlyList<int> earlyStarts)
        {
            for (int k = 0; k < _technologicalConditions.Count; k++)
            {
                yield return lateStarts[k] - earlyStarts[k];
            }
        }
    }
}
