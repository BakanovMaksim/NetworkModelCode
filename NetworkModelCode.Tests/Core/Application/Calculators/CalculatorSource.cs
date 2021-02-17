﻿using NetworkModelCode.Core.Domain.Entities;

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

        internal static IEnumerable<TestCaseData> GetMinimums()
        {
            yield return new TestCaseData(
                new List<double> { 25, 20, 24, 13, 100, 25, 25, 25, 25, 0, 27 });
        }

        internal static IEnumerable<TestCaseData> GetMaximums()
        {
            yield return new TestCaseData(
                new List<double> { 50, 40, 47, 100, 200, 50, 50, 50, 50, 50, 50 });
        }

        internal static IEnumerable<TestCaseData> GetTimePossibleMinimums()
        {
            yield return new TestCaseData(
                new List<double> { 25, 20, 24, 13, 100, 25, 25, 25, 25, 7, 27 });
        }

        internal static IEnumerable<TestCaseData> GetTimePossibleMaximums()
        {
            yield return new TestCaseData(
                new List<double> { 10, 7, 6, 4, 13, 4, 19, 6, 7, 12, 3 });
        }

        internal static IEnumerable<TestCaseData> GetCheckSystem()
        {
            yield return new TestCaseData(false);
        }

        internal static IReadOnlyList<TechnologicalCondition> GetTechnologicalConditions()
        {
            return new List<TechnologicalCondition>
            {
                new TechnologicalCondition { Title = "A", CodeI = 1, CodeJ = 2, TimeMin =5, TimeMax = 10,Time = 10 , ResourceCapacity=500, ResourceConsumptionRateMin=10, ResourceConsumptionRateMax = 20},
                new TechnologicalCondition { Title = "B", CodeI = 1, CodeJ = 4, TimeMin = 2, TimeMax = 7,Time = 4 , ResourceCapacity=800, ResourceConsumptionRateMin=20, ResourceConsumptionRateMax = 40},
                new TechnologicalCondition { Title = "C", CodeI = 1, CodeJ = 5, TimeMin = 1, TimeMax = 6,Time = 3 , ResourceCapacity=700, ResourceConsumptionRateMin=15, ResourceConsumptionRateMax = 30},
                new TechnologicalCondition { Title = "D", CodeI = 2, CodeJ = 3, TimeMin = 1,TimeMax=4,Time = 3 , ResourceCapacity=1300, ResourceConsumptionRateMin=0, ResourceConsumptionRateMax = 100},
                new TechnologicalCondition { Title = "F", CodeI = 2, CodeJ = 8, TimeMin = 8, TimeMax = 13,Time = 10, ResourceCapacity=600, ResourceConsumptionRateMin=3, ResourceConsumptionRateMax = 6},
                new TechnologicalCondition { Title = "E", CodeI = 3, CodeJ = 4, TimeMin = 1, TimeMax = 4,Time = 2 , ResourceCapacity=500, ResourceConsumptionRateMin=10, ResourceConsumptionRateMax = 20},
                new TechnologicalCondition { Title = "G", CodeI = 3, CodeJ = 6, TimeMin = 9, TimeMax = 19,Time = 13 , ResourceCapacity=500, ResourceConsumptionRateMin=10, ResourceConsumptionRateMax = 20},
                new TechnologicalCondition { Title = "H", CodeI = 4, CodeJ = 7, TimeMin = 4, TimeMax = 6,Time = 5, ResourceCapacity=500, ResourceConsumptionRateMin=10, ResourceConsumptionRateMax = 20 },
                new TechnologicalCondition{ Title = "M", CodeI = 5, CodeJ=7, TimeMin = 2, TimeMax = 7,Time = 3, ResourceCapacity=500, ResourceConsumptionRateMin=10, ResourceConsumptionRateMax = 20},
                new TechnologicalCondition{Title = "N", CodeI = 6, CodeJ = 8,TimeMin = 7,TimeMax=12,Time = 9, ResourceCapacity=500, ResourceConsumptionRateMin=10, ResourceConsumptionRateMax = 0},
                new TechnologicalCondition{Title = "K",CodeI = 7, CodeJ = 8, TimeMin=1,TimeMax = 3,Time = 6, ResourceCapacity=500, ResourceConsumptionRateMin=10, ResourceConsumptionRateMax = 19}
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
