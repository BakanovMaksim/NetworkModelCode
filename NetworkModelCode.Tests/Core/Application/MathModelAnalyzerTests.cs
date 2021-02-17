using NetworkModelCode.Core.Application;
using NetworkModelCode.Tests.Core.Application.Calculators;

using NUnit.Framework;

using System.Collections.Generic;

namespace NetworkModelCode.Tests.Core.Application
{
    [TestFixture]
    public class MathModelAnalyzerTests
    {
        private MathModelAnalyzer Analyzer { get; set; }

        [SetUp]
        public void SetUp()
        {
            Analyzer = new MathModelAnalyzer(CalculatorSource.GetTechnologicalConditions());
        }

        [TestCaseSource(typeof(CalculatorSource),nameof(CalculatorSource.GetTimePossibleMinimums))]
        public void GetTimePossibleMinTests(IEnumerable<double> expected)
        {
            var actual = Analyzer.GetTimePossibleMin();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(CalculatorSource),nameof(CalculatorSource.GetTimePossibleMaximums))]
        public void GetTimePossibleMaxTests(IEnumerable<double> expected)
        {
            var actual = Analyzer.GetTimePossibleMax();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(CalculatorSource),nameof(CalculatorSource.GetCheckSystem))]
        public void CheckCompatibilitySystemTests(bool expected)
        {
            var actual = Analyzer.CheckCompatibilitySystem();

            Assert.AreEqual(expected, actual);
        }
    }
}
