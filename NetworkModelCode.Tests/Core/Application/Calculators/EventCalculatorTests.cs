using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Core.Application.Calculators;

using NUnit.Framework;

using System.Collections.Generic;

namespace NetworkModelCode.Tests.Core.Application.Calculators
{
    [TestFixture]
    public class EventCalculatorTests
    {
        [Test]
        public void CalculateTests()
        {
            var expected = new List<int>
            {
                0,7,9,11,3,22,16,31
            };
            var technologicalConditions = new List<TechnologicalCondition>
            {
                         new TechnologicalCondition { Title = "A", CodeI = 1, CodeJ = 2, TimeMin =5, TimeMax = 10 },
                        new TechnologicalCondition { Title = "B", CodeI = 1, CodeJ = 4, TimeMin = 2, TimeMax = 7 },
                        new TechnologicalCondition { Title = "C", CodeI = 1, CodeJ = 5, TimeMin = 1, TimeMax = 6 },
                        new TechnologicalCondition { Title = "D", CodeI = 2, CodeJ = 3, TimeMin = 1,TimeMax=4 },
                        new TechnologicalCondition { Title = "F", CodeI = 2, CodeJ = 8, TimeMin = 8, TimeMax = 13},
                        new TechnologicalCondition { Title = "E", CodeI = 3, CodeJ = 4, TimeMin = 1, TimeMax = 4 },
                        new TechnologicalCondition { Title = "G", CodeI = 3, CodeJ = 6, TimeMin = 9, TimeMax = 19 },
                        new TechnologicalCondition { Title = "H", CodeI = 4, CodeJ = 7, TimeMin = 4, TimeMax = 6 },
                        new TechnologicalCondition{ Title = "M", CodeI = 5, CodeJ=7, TimeMin = 2, TimeMax = 7},
                        new TechnologicalCondition{Title = "N", CodeI = 6, CodeJ = 8,TimeMin = 7,TimeMax=12},
                        new TechnologicalCondition{Title = "K",CodeI = 7, CodeJ = 8, TimeMin=1,TimeMax = 3}
            };

            var calculator = new EventCalculator();
            calculator.Calculate(technologicalConditions);
            var actual = calculator.CalculateEarlyCompletionDate();

            Assert.AreEqual(expected, actual);
        }
    }
}
