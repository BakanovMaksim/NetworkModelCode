using NetworkModelCode.Core.Domain.Entities;

using NUnit.Framework;

using System.Collections.Generic;

namespace NetworkModelCode.Tests.Core.Application.Calculators
{
    internal class CalculatorSource
    {
        internal static IEnumerable<TestCaseData> GetEarlys()
        {
            yield return new TestCaseData(
                new List<int> { 0, 0, 0, 7, 7, 10, 10, 12, 3, 23, 17 },
                new List<int> { 10, 4, 3, 10, 17, 12, 23, 17, 6, 32, 23 });
        }

        internal static IEnumerable<TestCaseData> GetLates()
        {
            yield return new TestCaseData(
                new List<int> { 0, 20, 23, 10, 25, 22, 13, 24, 26, 26, 29 },
                new List<int> { 10, 24, 26, 13, 35, 24, 26, 29, 29, 35, 35 });
        }

        internal static IEnumerable<TestCaseData> GetReserves()
        {
            yield return new TestCaseData(
                new List<int> { 0, 20, 23, 3, 18, 12, 3, 12, 23, 3, 12 },
                new List<int> { 0, 20, 23, 3, 18, 12, 3, 12, 23, 3, 12 });
        }

        internal static IEnumerable<TestCaseData> GetCycleCountValues()
        {
            yield return new TestCaseData(
                new List<int> { 1, 2, 1, 2, 1, 2, 1, 1, 1, 3, 2 });
        }

        internal static IEnumerable<TestCaseData> GetCycleNumbers()
        {
            yield return new TestCaseData(
                new List<int> { 1, 1, 1, 2, 2, 4, 4, 6, 2, 5, 7 },
                new List<int> { 1, 2, 1, 3, 2, 5, 4, 6, 2, 7, 8 });
        }

        internal static IEnumerable<TestCaseData> GetResourceConsumptions()
        {
            yield return new TestCaseData(
                new List<double> { 5, 4, 2, 4, 5, 1.5, 2, 4, 5, 2.3, 1.5 });
        }

        internal static IEnumerable<TestCaseData> GetCycleNumberConsumptions()
        {
            yield return new TestCaseData(
                new List<List<int>>
                {
                    new List<int>{1},
                    new List<int>{1,2},
                    new List<int>{1},
                    new List<int>{2,3},
                    new List<int>{2},
                    new List<int>{4,5},
                    new List<int>{4},
                    new List<int>{6},
                    new List<int>{2},
                    new List<int>{5,6,7},
                    new List<int>{7,8}
                });
        }

        internal static IReadOnlyList<TechnologicalCondition> GetTechnologicalConditions()
        {
            return new List<TechnologicalCondition>
            {
                new TechnologicalCondition { Title = "A", CodeI = 1, CodeJ = 2, Time = 7 , ResourceCapacity=5, ResourceConsumptionMax=5, ResourceConsumptionMin = 1},
                new TechnologicalCondition { Title = "B", CodeI = 1, CodeJ = 4, Time = 4 , ResourceCapacity=8, ResourceConsumptionMax=4, ResourceConsumptionMin = 3},
                new TechnologicalCondition { Title = "C", CodeI = 1, CodeJ = 5, Time = 3 , ResourceCapacity=2, ResourceConsumptionMax=2, ResourceConsumptionMin = 1},
                new TechnologicalCondition { Title = "D", CodeI = 2, CodeJ = 3, Time = 2 , ResourceCapacity=8, ResourceConsumptionMax=4, ResourceConsumptionMin = 3},
                new TechnologicalCondition { Title = "F", CodeI = 2, CodeJ = 8, Time = 10, ResourceCapacity=5, ResourceConsumptionMax=5, ResourceConsumptionMin = 1},
                new TechnologicalCondition { Title = "E", CodeI = 3, CodeJ = 4, Time = 2 , ResourceCapacity=3, ResourceConsumptionMax=2, ResourceConsumptionMin = 1},
                new TechnologicalCondition { Title = "G", CodeI = 3, CodeJ = 6, Time = 13 , ResourceCapacity=2, ResourceConsumptionMax=2, ResourceConsumptionMin = 1},
                new TechnologicalCondition { Title = "H", CodeI = 4, CodeJ = 7, Time = 5, ResourceCapacity=4, ResourceConsumptionMax=4, ResourceConsumptionMin = 1 },
                new TechnologicalCondition{ Title = "M", CodeI = 5, CodeJ=7, Time = 4, ResourceCapacity=5, ResourceConsumptionMax=5, ResourceConsumptionMin = 1},
                new TechnologicalCondition{Title = "N", CodeI = 6, CodeJ = 8, Time = 9, ResourceCapacity=7, ResourceConsumptionMax=3, ResourceConsumptionMin = 3},
                new TechnologicalCondition{Title = "K",CodeI = 7, CodeJ = 8, Time = 2, ResourceCapacity=3, ResourceConsumptionMax=2, ResourceConsumptionMin = 1}
            };
        }

        internal static IReadOnlyList<NetworkEvent> GetNetworkEvents()
        {
            return new List<NetworkEvent>
            {
                new NetworkEvent{EarlyCompletionDate=0,LateCompletionDate=0,TimeReserveCompletionDate=0},
                new NetworkEvent{EarlyCompletionDate=10,LateCompletionDate=10,TimeReserveCompletionDate=0},
                new NetworkEvent{EarlyCompletionDate=13,LateCompletionDate=13,TimeReserveCompletionDate=0},
                new NetworkEvent{EarlyCompletionDate=15,LateCompletionDate=24,TimeReserveCompletionDate=9},
                new NetworkEvent{EarlyCompletionDate=3,LateCompletionDate=26,TimeReserveCompletionDate=23},
                new NetworkEvent{EarlyCompletionDate=26,LateCompletionDate=26,TimeReserveCompletionDate=0},
                new NetworkEvent{EarlyCompletionDate=20,LateCompletionDate=29,TimeReserveCompletionDate=9},
                new NetworkEvent{EarlyCompletionDate=35,LateCompletionDate=35,TimeReserveCompletionDate=0}
            };
        }
    }
}
