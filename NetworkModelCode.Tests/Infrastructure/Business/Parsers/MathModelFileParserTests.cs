using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Infrastructure.Business.Parsers;

using NUnit.Framework;

using System.Collections.Generic;

namespace NetworkModelCode.Tests.Infrastructure.Business.Parsers
{
    [TestFixture]
    internal class WorkTextParserTests
    {
        internal WorkTextParser Parser { get; set; }

        [SetUp]
        public void SetUp()
        {
            Parser = new();
        }

        [TestCaseSource(typeof(ParserSource), nameof(ParserSource.GetBuffers))] 
        public void TryParseWorkDataSourceTests(string buffer, bool expectedIsTry, IReadOnlyList<ItemDataSource> expectedWorkDataSource)
        {
            var actualIsTry = Parser.TryParseWorkDataSource(buffer, out var actualWorkDataSource);

            Assert.AreEqual(expectedIsTry, actualIsTry);
            if (expectedIsTry)
            {
                CollectionAssert.AreEqual(expectedWorkDataSource, actualWorkDataSource);
            }
        }
    }
}
