using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Core.Domain.Entities;

using NUnit.Framework;

using System.Collections.Generic;
using System.Linq;

namespace NetworkModelCode.Tests.Core.Application.Calculators
{
    [TestFixture]
    internal class TimeCharacteristicCalculatorTests
    {
        internal TimeCharacteristicCalculator TimeCharacteristicCalculator { get; set; }
        internal IReadOnlyList<TimeCharacteristic> TimeCharacteristics { get; set; }

        [SetUp]
        public void SetUp()
        {
            TimeCharacteristicCalculator = new();

            TimeCharacteristics = TimeCharacteristicCalculator.Calculate(CalculatorSource.GetWorkDataSource()).ToList();
        }

        [TestCaseSource(typeof(CalculatorSource), nameof(CalculatorSource.GetEarlys))]
        public void CalculateEarlysTests(IReadOnlyList<int> expectedEarlyStarts, IReadOnlyList<int> expectedEarlyFinishes)
        {
            for(int k = 0;k< TimeCharacteristics.Count; k++)
            {
                var actualEarlyStart = TimeCharacteristics[k].EarlyStart;
                var actualEarlyFinish = TimeCharacteristics[k].EarlyFinish;
                Assert.AreEqual(expectedEarlyStarts[k], actualEarlyStart);
                Assert.AreEqual(expectedEarlyFinishes[k], actualEarlyFinish);
            }
        }

        [TestCaseSource(typeof(CalculatorSource), nameof(CalculatorSource.GetLates))]
        public void CalculateLatesTests(IReadOnlyList<int> expectedLateStarts, IReadOnlyList<int> expectedLateFinishes)
        {
            for(int k = 0; k < TimeCharacteristics.Count; k++)
            {
                var actualLateStart = TimeCharacteristics[k].LateStart;
                var actualLateFinish = TimeCharacteristics[k].LateFinish;
                Assert.AreEqual(expectedLateStarts[k], actualLateStart);
                Assert.AreEqual(expectedLateFinishes[k], actualLateFinish);
            }
        }

        [TestCaseSource(typeof(CalculatorSource), nameof(CalculatorSource.GetReserves))]
        public void CalculateReservesTests(IReadOnlyList<int> expectedReserveFullTimes, IReadOnlyList<int> expectedReserveFreeTimes)
        {
            for(int k = 0; k < TimeCharacteristics.Count; k++)
            {
                var actualReserveFullTime = TimeCharacteristics[k].ReserveFullTime;
                var actualReserveFreeTime = TimeCharacteristics[k].ReserveFreeTime;
                Assert.AreEqual(expectedReserveFullTimes[k], actualReserveFullTime);
                Assert.AreEqual(expectedReserveFreeTimes[k], actualReserveFreeTime);
            }
        }
    }
}
