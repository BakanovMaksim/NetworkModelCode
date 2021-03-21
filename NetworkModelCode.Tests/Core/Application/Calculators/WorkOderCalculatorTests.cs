using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Core.Domain.Entities;

using NUnit.Framework;

using System.Collections.Generic;
using System.Linq;

namespace NetworkModelCode.Tests.Core.Application.Calculators
{
    [TestFixture]
    public class WorkOderCalculatorTests
    {
        private IReadOnlyList<TimeCharacteristic> _timeCharacteristics;
        private IReadOnlyList<VariableParameter> _variableParameters;

        [SetUp]
        public void SetUp()
        {
            var timeCharacteristicCalculator = new TimeCharacteristicCalculator(CalculatorSource.GetTechnologicalConditions());
            _timeCharacteristics = timeCharacteristicCalculator.Calculate().ToList();

            var variableParameterCalculator = new VariableParameterCalculator(CalculatorSource.GetTechnologicalConditions());
            _variableParameters = variableParameterCalculator.Calculate(12).ToList();
        }

        [Test]
        public void CalculateTests()
        {
            var actual = WorkOrderCalculator.Calculate(_timeCharacteristics, _variableParameters);

            CollectionAssert.AreEqual(new List<TimeCharacteristic>(), actual);
        }
    }
}
