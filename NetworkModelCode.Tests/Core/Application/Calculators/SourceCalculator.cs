using NUnit.Framework;

using System.Collections.Generic;

namespace NetworkModelCode.Tests.Core.Application.Calculators
{
    public class SourceCalculator
    {
        public static IEnumerable<TestCaseData> GetEarlyStartsAndEnds()
        {
            yield return new TestCaseData(
                new List<int> { 0, 0, 5, 5, 5, 5, 12, 11 },
                new List<int> { 5, 2, 5, 8, 12, 11, 16, 16 });
        }

        public static IEnumerable<TestCaseData> GetLateStarts()
        {
            yield return new TestCaseData(
                new List<int> { 0, 3, 5, 9, 5, 5, 12, 11 });
        }

        public static IEnumerable<TestCaseData> GetLateEnds()
        {
            yield return new TestCaseData(
                new List<int> { 5, 5, 5, 12, 12, 11, 16, 16 });
        }

        public static IEnumerable<TestCaseData> GetTimeReserves()
        {
            yield return new TestCaseData(
                new List<int> { 0, 3, 0, 4, 0, 0, 0, 0 });
        }
    }
}
