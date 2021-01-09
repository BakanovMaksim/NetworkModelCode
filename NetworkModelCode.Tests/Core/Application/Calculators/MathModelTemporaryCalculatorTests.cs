using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Core.Domain.Builders;
using NetworkModelCode.Core.Domain.Entities;

using NUnit.Framework;

using System.Collections.Generic;
using System.Linq;

namespace NetworkModelCode.Tests.Core.Application.Calculators
{
    [TestFixture]
    public class MathModelTemporaryCalculatorTests
    {
        private MathModelTemporaryCalculator MathModelTemporaryCalculator { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mathModelSource = GetMathModelSource();

            MathModelTemporaryCalculator = new MathModelTemporaryCalculator(mathModelSource);
        }

        [TestCaseSource(typeof(SourceCalculator), nameof(SourceCalculator.GetEarlyStartsAndEnds))]
        public void CalculateEarlyStartsAndEndsTests(IReadOnlyList<int> expectedEarlyStarts, IReadOnlyList<int> expectedEarlyEnds)
        {
            var (earlyStarts, earlyEnds) = MathModelTemporaryCalculator.CalculateEarlyStartsAndEnds();

            var actualEarlyStarts = earlyStarts.ToList();
            var actualEarlyEnds = earlyEnds.ToList();
            for (int k = 0; k < expectedEarlyStarts.Count; k++)
            {
                Assert.AreEqual(expectedEarlyStarts[k], actualEarlyStarts[k]);
                Assert.AreEqual(expectedEarlyEnds[k], actualEarlyEnds[k]);
            }
        }

        [TestCaseSource(typeof(SourceCalculator), nameof(SourceCalculator.GetLateEnds))]
        public void CalculateLateEndsTests(IReadOnlyList<int> expectedLateStarts)
        {
            var (earlyStarts, earlyEnds) = MathModelTemporaryCalculator.CalculateEarlyStartsAndEnds();
            var lateEnds = MathModelTemporaryCalculator.CalculateLateEnds(earlyEnds);

            var actualLateEnds = lateEnds.ToList();
            for (int k = 0; k < expectedLateStarts.Count; k++)
            {
                Assert.AreEqual(expectedLateStarts[k], actualLateEnds[k]);
            }
        }

        [TestCaseSource(typeof(SourceCalculator), nameof(SourceCalculator.GetLateStarts))]
        public void CalculateLateStartsTests(IReadOnlyList<int> expectetLateStarts)
        {
            var (earlyStarts, earlyEnds) = MathModelTemporaryCalculator.CalculateEarlyStartsAndEnds();
            var lateEnds = MathModelTemporaryCalculator.CalculateLateEnds(earlyEnds);
            var lateStarts = MathModelTemporaryCalculator.CalculateLateStarts(lateEnds);

            var actualLateStarts = lateStarts.ToList();
            for (int k = 0; k < expectetLateStarts.Count; k++)
            {
                Assert.AreEqual(expectetLateStarts[k], actualLateStarts[k]);
            }
        }

        [TestCaseSource(typeof(SourceCalculator), nameof(SourceCalculator.GetTimeReserves))]
        public void CalculateFullTimeReservesTests(IReadOnlyList<int> expectedFullTimeReserves)
        {
            var (earlyStarts, earlyEnds) = MathModelTemporaryCalculator.CalculateEarlyStartsAndEnds();
            var lateEnds = MathModelTemporaryCalculator.CalculateLateEnds(earlyEnds);

            var actualFullTimeReserves = MathModelTemporaryCalculator.CalculateFullTimeReserves(lateEnds, earlyEnds).ToList();

            for (int k = 0; k < expectedFullTimeReserves.Count; k++)
            {
                Assert.AreEqual(expectedFullTimeReserves[k], actualFullTimeReserves[k]);
            }
        }

        [TestCaseSource(typeof(SourceCalculator), nameof(SourceCalculator.GetTimeReserves))]
        public void CalculateFreeTimeReservesTests(IReadOnlyList<int> expectedFreeTimeReserves)
        {
            var (earlyStarts, earlyEnds) = MathModelTemporaryCalculator.CalculateEarlyStartsAndEnds();
            var lateEnds = MathModelTemporaryCalculator.CalculateLateEnds(earlyEnds);
            var lateStarts = MathModelTemporaryCalculator.CalculateLateStarts(lateEnds);

            var actualFreeTimeReserves = MathModelTemporaryCalculator.CalculateFreeTimeReserves(lateStarts, earlyStarts).ToList();

            for (int k = 0; k < expectedFreeTimeReserves.Count; k++)
            {
                Assert.AreEqual(expectedFreeTimeReserves[k], actualFreeTimeReserves[k]);
            }
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
