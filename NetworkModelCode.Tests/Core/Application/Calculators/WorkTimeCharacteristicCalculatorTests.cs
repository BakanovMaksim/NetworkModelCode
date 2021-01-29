using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Core.Domain.Entities;

using NUnit.Framework;

using System.Collections.Generic;
using System.Linq;

namespace NetworkModelCode.Tests.Core.Application.Calculators
{
    [TestFixture]
    internal class WorkTimeCharacteristicCalculatorTests
    {
        internal WorkTimeCharacteristicCalculator WorkTimeCharacteristicCalculator { get; set; }
        internal IReadOnlyList<ItemTimeCharacteristic> WorkTimeCharacteristics { get; set; }

        [SetUp]
        public void SetUp()
        {
            WorkTimeCharacteristicCalculator = new();

            WorkTimeCharacteristics = WorkTimeCharacteristicCalculator.Calculate(CalculatorSource.GetWorkDataSource()).ToList();
        }

        [TestCaseSource(typeof(CalculatorSource), nameof(CalculatorSource.GetEarlys))]
        public void CalculateEarlysTests(IReadOnlyList<int> expectedEarlyStarts, IReadOnlyList<int> expectedEarlyFinishes)
        {
            for(int k = 0;k< WorkTimeCharacteristics.Count; k++)
            {
                var actualEarlyStart = WorkTimeCharacteristics[k].EarlyStart;
                var actualEarlyFinish = WorkTimeCharacteristics[k].EarlyFinish;
                Assert.AreEqual(expectedEarlyStarts[k], actualEarlyStart);
                Assert.AreEqual(expectedEarlyFinishes[k], actualEarlyFinish);
            }
        }

        [TestCaseSource(typeof(CalculatorSource), nameof(CalculatorSource.GetLates))]
        public void CalculateLatesTests(IReadOnlyList<int> expectedLateStarts, IReadOnlyList<int> expectedLateFinishes)
        {
            for(int k = 0; k < WorkTimeCharacteristics.Count; k++)
            {
                var actualLateStart = WorkTimeCharacteristics[k].LateStart;
                var actualLateFinish = WorkTimeCharacteristics[k].LateFinish;
                Assert.AreEqual(expectedLateStarts[k], actualLateStart);
                Assert.AreEqual(expectedLateFinishes[k], actualLateFinish);
            }
        }

        [TestCaseSource(typeof(CalculatorSource), nameof(CalculatorSource.GetReserves))]
        public void CalculateReservesTests(IReadOnlyList<int> expectedReserveFullTimes, IReadOnlyList<int> expectedReserveFreeTimes)
        {
            for(int k = 0; k < WorkTimeCharacteristics.Count; k++)
            {
                var actualReserveFullTime = WorkTimeCharacteristics[k].ReserveFullTime;
                var actualReserveFreeTime = WorkTimeCharacteristics[k].ReserveFreeTime;
                Assert.AreEqual(expectedReserveFullTimes[k], actualReserveFullTime);
                Assert.AreEqual(expectedReserveFreeTimes[k], actualReserveFreeTime);
            }
        }
    }
}
