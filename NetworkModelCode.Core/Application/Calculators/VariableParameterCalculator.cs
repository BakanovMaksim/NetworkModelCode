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
        private IEnumerable<TechnologicalCondition> TechnologicalConditions { get; set; }

        public VariableParameterCalculator(IEnumerable<TechnologicalCondition> technologicalConditions)
        {
            TechnologicalConditions = technologicalConditions;
        }

        public IEnumerable<VariableParameter> Calculate(int cycleCount)
        {
            CycleCountValues = CalculateCycleCountValues().ToList();

            var starts = CalculateCycleNumbers().Item1.ToList();
            var finishes = CalculateCycleNumbers().Item2.ToList();
            var resourceConsumptions = CalculateResourceConsumptions(starts, finishes).ToList();
            var cycleNumberConsumptions = CalculateCycleNumberConsumptions(cycleCount, starts, finishes).ToList();

            for(int k = 0;k< starts.Count;k++)
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

        internal (IEnumerable<int>,IEnumerable<int>) CalculateCycleNumbers()
        {
            var startCycleNumbers = new List<int>(TechnologicalConditions.Count());
            var finishCycleNumbers = new List<int>(TechnologicalConditions.Count());

            foreach(var item in TechnologicalConditions)
            {
                var index = TechnologicalConditions.ToList().IndexOf(item);

                if (TechnologicalConditions.FirstOrDefault(p => p.CodeJ == item.CodeI) == null)
                {
                    startCycleNumbers.Add(1);
                    finishCycleNumbers.Add(1 + CycleCountValues[index] - 1);
                    continue;
                }

                var indexes = TechnologicalConditions
                    .Where(p => p.CodeJ == item.CodeI)
                    .Select(p => TechnologicalConditions.ToList().IndexOf(p));

                var collection = indexes.Select(p => finishCycleNumbers[p]);

                startCycleNumbers.Add(collection.Max() + 1);
                finishCycleNumbers.Add(startCycleNumbers[index] + CycleCountValues[index] - 1);
            }

            return (startCycleNumbers, finishCycleNumbers);
        }

        internal IEnumerable<double> CalculateResourceConsumptions(IReadOnlyList<int> starts, IReadOnlyList<int> finishes)
        {
            for (int k = 0; k < TechnologicalConditions.Count(); k++)
            {
                var resourceCapacity = TechnologicalConditions.ElementAtOrDefault(k).ResourceCapacity;

                yield return Math.Round(resourceCapacity / (finishes[k] - starts[k] + 1), 1);
            }
        }

        internal IEnumerable<IEnumerable<int>> CalculateCycleNumberConsumptions(int cycleCount, IReadOnlyList<int> starts, IReadOnlyList<int> finishes)
        {
            for (int k = 0; k < starts.Count; k++)
            {
                var numbers = new List<int>();

                for(int t = 0;t<cycleCount;t++)
                {
                    if((t >= starts[k]) && (t <= finishes[k])) numbers.Add(t);
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
            foreach (var item in TechnologicalConditions)
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
