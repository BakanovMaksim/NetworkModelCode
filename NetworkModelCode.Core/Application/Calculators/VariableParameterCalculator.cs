using NetworkModelCode.Core.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NetworkModelCode.Tests")]
namespace NetworkModelCode.Core.Application.Calculators
{
    public class VariableParameterCalculator
    {
        internal IReadOnlyList<int> CycleCountValues { get; set; }
        private IEnumerable<TechnologicalCondition> _technologicalConditions;

        public VariableParameterCalculator(IEnumerable<TechnologicalCondition> technologicalConditions)
        {
            if (technologicalConditions == null)
            {
                throw new ArgumentNullException("Передана пустая ссылка.", nameof(technologicalConditions));
            }

            _technologicalConditions = technologicalConditions;
        }

        public IEnumerable<VariableParameter> Calculate(int cycleCount)
        {
            CycleCountValues = CalculateCycleCountValues().ToList();

            var starts = CalculateCycleNumbers().Item1.ToList();
            var finishes = CalculateCycleNumbers().Item2.ToList();
            var resourceConsumptions = CalculateResourceConsumptions(starts, finishes).ToList();
            var cycleNumberConsumptions = CalculateCycleNumberConsumptions(cycleCount, starts, finishes).ToList();

            for (int k = 0; k < starts.Count; k++)
            {
                yield return new VariableParameter
                {
                    StartCycleNumber = starts[k],
                    FinishCycleNumber = finishes[k],
                    ResourceConsumption = resourceConsumptions[k],
                    CycleNumberConsumptions = cycleNumberConsumptions[k]
                };
            }
        }

        internal (IEnumerable<int>, IEnumerable<int>) CalculateCycleNumbers()
        {
            var startCycleNumbers = new List<int>(_technologicalConditions.Count());
            var finishCycleNumbers = new List<int>(_technologicalConditions.Count());

            foreach (var item in _technologicalConditions)
            {
                var index = _technologicalConditions.ToList().IndexOf(item);

                if (_technologicalConditions.FirstOrDefault(p => p.CodeJ == item.CodeI) == null)
                {
                    startCycleNumbers.Add(1);
                    finishCycleNumbers.Add(1 + CycleCountValues[index] - 1);
                    continue;
                }

                var indexes = _technologicalConditions
                    .Where(p => p.CodeJ == item.CodeI)
                    .Select(p => _technologicalConditions.ToList().IndexOf(p));

                var collection = indexes.Select(p => finishCycleNumbers[p]);

                startCycleNumbers.Add(collection.Max() + 1);
                finishCycleNumbers.Add(startCycleNumbers[index] + CycleCountValues[index] - 1);
            }

            return (startCycleNumbers, finishCycleNumbers);
        }

        internal IEnumerable<double> CalculateResourceConsumptions(IReadOnlyList<int> starts, IReadOnlyList<int> finishes)
        {
            for (int k = 0; k < _technologicalConditions.Count(); k++)
            {
                var resourceCapacity = _technologicalConditions.ElementAtOrDefault(k).ResourceCapacity;

                yield return Math.Round(resourceCapacity / (finishes[k] - starts[k] + 1), 1);
            }
        }

        internal IEnumerable<IEnumerable<int>> CalculateCycleNumberConsumptions(int cycleCount, IReadOnlyList<int> starts, IReadOnlyList<int> finishes)
        {
            for (int k = 0; k < starts.Count; k++)
            {
                var numbers = new List<int>();

                for (int t = 0; t < cycleCount; t++)
                {
                    if ((t >= starts[k]) && (t <= finishes[k])) numbers.Add(t);
                }

                yield return numbers;
            }
        }

        internal IEnumerable<int> CalculateCycleCountValues()
        {
            return CalculateIntermediateValues();
        }

        private IEnumerable<int> CalculateIntermediateValues()
        {
            foreach (var item in _technologicalConditions)
            {
                if (item.ResourceConsumptionMax == 0)
                {
                    yield return 0;
                    continue;
                }

                var value = item.ResourceCapacity / item.ResourceConsumptionMax;

                if ((item.ResourceCapacity % item.ResourceConsumptionMax) == 0)
                {
                    yield return (int)value;
                }
                else
                {
                    yield return (int)(Math.Truncate(value) + 1);
                }

            }
        }
    }
}
