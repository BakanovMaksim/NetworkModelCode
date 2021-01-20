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
                new List<int> { 0, 0, 5, 5, 5, 5, 12, 11 },
                new List<int> { 5, 2, 5, 8, 12, 11, 16, 16 });
        }

        internal static IEnumerable<TestCaseData> GetLates()
        {
            yield return new TestCaseData(
                new List<int> { 0, 3, 5, 9, 5, 5, 12, 11 },
                new List<int> { 5, 5, 5, 12, 12, 11, 16, 16 });
        }

        internal static IEnumerable<TestCaseData> GetReserves()
        {
            yield return new TestCaseData(
                new List<int> { 0, 3, 0, 4, 0, 0, 0, 0 },
                new List<int> { 0, 3, 0, 4, 0, 0, 0, 0 });
        }

        internal static WorkManager GetWorkManager()
        {
            return new WorkManager
            {
                WorkCount = 8,
                WorkDataSources = new List<WorkDataSource>
                {
                    new WorkDataSource { CodeI = 1, CodeJ = 2, Time = 5 },
                    new WorkDataSource { CodeI = 1, CodeJ = 3, Time = 2 },
                    new WorkDataSource { CodeI = 2, CodeJ = 3, Time = 0 },
                    new WorkDataSource { CodeI = 2, CodeJ = 4, Time = 3 },
                    new WorkDataSource { CodeI = 3, CodeJ = 4, Time = 7 },
                    new WorkDataSource { CodeI = 3, CodeJ = 5, Time = 6 },
                    new WorkDataSource { CodeI = 4, CodeJ = 6, Time = 4 },
                    new WorkDataSource { CodeI = 5, CodeJ = 6, Time = 5 }
                }
            };
        }
    }
}
