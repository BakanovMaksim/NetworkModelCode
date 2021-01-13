using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Infrastructure.Business.Parsers;

using NUnit.Framework;

using System.Collections.Generic;

namespace NetworkModelCode.Tests.Infrastructure.Business.Parsers
{
    [TestFixture]
    internal class MathModelFileParserTests
    {
        internal MathModelFileParser Parser { get; set; }

        [SetUp]
        public void SetUp()
        {
            Parser = new MathModelFileParser();
        }

        [TestCaseSource(typeof(ParserSource),nameof(ParserSource.GetBuffers))]
        public void TryParseTests(string buffer, bool expectedIsTry, IReadOnlyList<WorkCode> expectedWorkCodes, IReadOnlyList<int> expectedExecutionTimes)
        {
            var actualIsTry = Parser.TryParseSource(buffer, out var actualMathModelSource);

            Assert.AreEqual(expectedIsTry, actualIsTry);
            if (expectedIsTry)
            {
                Assert.AreEqual(expectedWorkCodes.Count, actualMathModelSource.NumberWorkCount);
                CollectionAssert.AreEqual(expectedExecutionTimes, actualMathModelSource.ExecutionTimes);
            }
        }
    }
}
