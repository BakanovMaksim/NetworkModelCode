using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Infrastructure.Business.Parsers;

using NUnit.Framework;

namespace NetworkModelCode.Tests.Infrastructure.Business.Parsers
{
    [TestFixture]
    internal class ProjectTextParserTests
    {
        internal ProjectTextParser Parser { get; set; }

        [SetUp]
        public void SetUp()
        {
            Parser = new();
        }

        [TestCaseSource(typeof(ParserSource), nameof(ParserSource.GetBuffers))] 
        public void TryParseProjectTests(string buffer, bool expectedIsTry, Project expectedProject)
        {
            var actualIsTry = ProjectTextParser.TryParseProject(buffer, out var actualProject);

            Assert.AreEqual(expectedIsTry, actualIsTry);
            if (expectedIsTry)
            {
                Assert.AreEqual(expectedProject.WorkCount, actualProject.WorkCount);
                CollectionAssert.AreEqual(expectedProject.ItemsDataSource, actualProject.ItemsDataSource);
                CollectionAssert.AreEqual(expectedProject.ItemsTimeCharacteristic, actualProject.ItemsTimeCharacteristic);
            }
        }
    }
}
