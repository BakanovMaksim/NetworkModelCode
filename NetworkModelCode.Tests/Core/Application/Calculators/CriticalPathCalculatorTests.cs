using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Core.Domain.Entities;

using NUnit.Framework;

using System.Collections.Generic;
using System.Linq;

namespace NetworkModelCode.Tests.Core.Application.Calculators
{
    [TestFixture]
    public class CriticalPathCalculatorTests
    {
        private IReadOnlyList<ItemDataSource> WorkDataSource { get; set; }
        private IReadOnlyList<ItemTimeCharacteristic> WorkTimeCharacteristics { get; set; }
        private CriticalPathCalculator CriticalPathCalculator { get; set; }
        private WorkTimeCharacteristicCalculator WorkTimeCharacteristicCalculator { get; set; }

        [SetUp]
        public void SetUp()
        {
            WorkDataSource = CalculatorSource.GetWorkDataSource();
   
            WorkTimeCharacteristicCalculator = new();
            WorkTimeCharacteristics = WorkTimeCharacteristicCalculator.Calculate(WorkDataSource).ToList();

            CriticalPathCalculator = new();
        }

        [TestCaseSource(typeof(CalculatorSource),nameof(CalculatorSource.GetCriticalPathLength))]
        public void CalculateTests(int expected)
        {
            var actual = CriticalPathCalculator.Calculate(WorkDataSource, WorkTimeCharacteristics);

            Assert.AreEqual(expected, actual);
        }
    }
}
