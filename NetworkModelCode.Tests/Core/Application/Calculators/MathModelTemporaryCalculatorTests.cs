using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Core.Domain.Builders;
using NetworkModelCode.Core.Domain.Entities;

using NUnit.Framework;

using System.Collections.Generic;
using System.Linq;

namespace NetworkModelCode.Tests.Core.Application.Calculators
{
    [TestFixture]
    internal class MathModelTemporaryCalculatorTests
    {
        internal MathModelTemporaryCalculator MathModelTemporaryCalculator { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mathModelSource = GetMathModelSource();

            MathModelTemporaryCalculator = new MathModelTemporaryCalculator(mathModelSource);
        }

        [TestCaseSource(typeof(CalculatorSource), nameof(CalculatorSource.GetEarlyStartsAndEnds))]
        public void CalculateEarlyStartsAndEndsTests(IEnumerable<int> expectedEarlyStarts, IEnumerable<int> expectedEarlyEnds)
        {
            var (earlyStarts, earlyEnds) = MathModelTemporaryCalculator.CalculateEarlyStartsAndEnds();

            var actualEarlyStarts = earlyStarts.ToList();
            var actualEarlyEnds = earlyEnds.ToList();
            CollectionAssert.AreEqual(expectedEarlyStarts, actualEarlyStarts);
            CollectionAssert.AreEqual(expectedEarlyEnds, actualEarlyEnds);
        }

        [TestCaseSource(typeof(CalculatorSource), nameof(CalculatorSource.GetLateEnds))]
        public void CalculateLateEndsTests(IEnumerable<int> expectedLateStarts)
        {
            var (earlyStarts, earlyEnds) = MathModelTemporaryCalculator.CalculateEarlyStartsAndEnds();
            var lateEnds = MathModelTemporaryCalculator.CalculateLateEnds(earlyEnds);

            var actualLateEnds = lateEnds.ToList();
            CollectionAssert.AreEqual(expectedLateStarts, actualLateEnds);
        }

        [TestCaseSource(typeof(CalculatorSource), nameof(CalculatorSource.GetLateStarts))]
        public void CalculateLateStartsTests(IEnumerable<int> expectetLateStarts)
        {
            var (earlyStarts, earlyEnds) = MathModelTemporaryCalculator.CalculateEarlyStartsAndEnds();
            var lateEnds = MathModelTemporaryCalculator.CalculateLateEnds(earlyEnds);
            var lateStarts = MathModelTemporaryCalculator.CalculateLateStarts(lateEnds);

            var actualLateStarts = lateStarts.ToList();
            CollectionAssert.AreEqual(expectetLateStarts, actualLateStarts);
        }

        [TestCaseSource(typeof(CalculatorSource), nameof(CalculatorSource.GetTimeReserves))]
        public void CalculateFullTimeReservesTests(IEnumerable<int> expectedFullTimeReserves)
        {
            var (earlyStarts, earlyEnds) = MathModelTemporaryCalculator.CalculateEarlyStartsAndEnds();
            var lateEnds = MathModelTemporaryCalculator.CalculateLateEnds(earlyEnds);

            var actualFullTimeReserves = MathModelTemporaryCalculator.CalculateFullTimeReserves(lateEnds, earlyEnds).ToList();

            CollectionAssert.AreEqual(expectedFullTimeReserves, actualFullTimeReserves);
        }

        [TestCaseSource(typeof(CalculatorSource), nameof(CalculatorSource.GetTimeReserves))]
        public void CalculateFreeTimeReservesTests(IEnumerable<int> expectedFreeTimeReserves)
        {
            var (earlyStarts, earlyEnds) = MathModelTemporaryCalculator.CalculateEarlyStartsAndEnds();
            var lateEnds = MathModelTemporaryCalculator.CalculateLateEnds(earlyEnds);
            var lateStarts = MathModelTemporaryCalculator.CalculateLateStarts(lateEnds);

            var actualFreeTimeReserves = MathModelTemporaryCalculator.CalculateFreeTimeReserves(lateStarts, earlyStarts).ToList();

            CollectionAssert.AreEqual(expectedFreeTimeReserves, actualFreeTimeReserves);
        }

        private MathModelSource GetMathModelSource()
        {
            var workCodes = GetWorkCodes();
            var executionTimes = GetExecutionTimes();

            return new MathModelSourceBuilder()
                .SetNumberWorkCount(8)
                .SetWorkCodes(workCodes)
                .SetExecutionTimes(executionTimes)
                .Build();
        }

        private IReadOnlyList<WorkCode> GetWorkCodes()
        {
            return new List<WorkCode>
            {
                new WorkCode(1,2),
                new WorkCode(1,3),
                new WorkCode(2,3),
                new WorkCode(2,4),
                new WorkCode(3,4),
                new WorkCode(3,5),
                new WorkCode(4,6),
                new WorkCode(5,6)
            };
        }

        private IReadOnlyList<int> GetExecutionTimes()
        {
            return new List<int>
            {
                5,2,0,3,7,6,4,5
            };
        }
    }
}
