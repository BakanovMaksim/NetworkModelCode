using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Core.Domain.Entities;

using NUnit.Framework;

using System.Collections.Generic;

namespace NetworkModelCode.Tests.Core.Application.Calculators
{
    [TestFixture]
    public class NetworkEventCalculatorTests
    {
        private IReadOnlyList<TechnologicalCondition> TechnologicalConditions { get; set; }

        [SetUp]
        public void SetUp()
        {
            TechnologicalConditions = CalculatorSource.GetTechnologicalConditions();
        }

        [Test]
        public void CalculateTests()
        {
            var expected = CalculatorSource.GetNetworkEvents();

            var actual = NetworkEventCalculator.Calculate(TechnologicalConditions);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
