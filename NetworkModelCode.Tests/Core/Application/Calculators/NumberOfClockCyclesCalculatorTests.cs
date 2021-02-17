using NetworkModelCode.Core.Application.Calculators;

using NUnit.Framework;

using System.Collections.Generic;

namespace NetworkModelCode.Tests.Core.Application.Calculators
{
    [TestFixture]
    public class NumberOfClockCyclesCalculatorTests
    {
        private NumberOfClockCyclesCalculator Calculator { get; set; }

        [SetUp]
        public void SetUp()
        {
            Calculator = new NumberOfClockCyclesCalculator(CalculatorSource.GetTechnologicalConditions());
        }

        [TestCaseSource(typeof(CalculatorSource), nameof(CalculatorSource.GetMinimums))]
        public void CalculateMinimumsTests(IEnumerable<double> expected)
        {
            var actual = Calculator.CalculateMinimums();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(CalculatorSource),nameof(CalculatorSource.GetMaximums))]
        public void CalculateMaximumsTests(IEnumerable<double> expected)
        {
            var actual = Calculator.CalculateMaximums();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
