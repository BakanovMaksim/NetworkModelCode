using NetworkModelCode.Core.Application.Calculators;

using NUnit.Framework;

using System.Collections.Generic;
using System.Linq;

namespace NetworkModelCode.Tests.Core.Application.Calculators
{
    [TestFixture]
    public class VariableParameterCalculatorTests
    {
        private VariableParameterCalculator Calculator { get; set; }

        [SetUp]
        public void SetUp()
        {
            Calculator = new VariableParameterCalculator(CalculatorSource.GetTechnologicalConditions());
        }

        [TestCaseSource(typeof(CalculatorSource), nameof(CalculatorSource.GetCycleCountValues))]
        public void CalculateCycleCountValuesTests(IEnumerable<int> expected)
        {
            var actual = Calculator.CalculateCycleCountValues();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(CalculatorSource),nameof(CalculatorSource.GetCycleNumbers))]
        public void CalculateCycleNumbersTests(IEnumerable<int> expectedStarts, IEnumerable<int> expectedFinishes)
        {
            Calculator.CycleCountValues = Calculator.CalculateCycleCountValues().ToList();

            var actual = Calculator.CalculateCycleNumbers();

            CollectionAssert.AreEqual(expectedStarts, actual.Item1);
            CollectionAssert.AreEqual(expectedFinishes, actual.Item2);
        }

        [TestCaseSource(typeof(CalculatorSource),nameof(CalculatorSource.GetResourceConsumptions))]
        public void CalculateResourceConsumptionsTests(IEnumerable<double> expected)
        {
            Calculator.CycleCountValues = Calculator.CalculateCycleCountValues().ToList();
            var (starts,finishes) = Calculator.CalculateCycleNumbers();

            var actual = Calculator.CalculateResourceConsumptions(starts.ToList(), finishes.ToList());

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
