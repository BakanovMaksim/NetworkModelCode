using NetworkModelCode.Infrastructure.Business;

using NUnit.Framework;

using System;
using System.Threading.Tasks;

namespace NetworkModelCode.Tests.Infrastructure.Business.Importers
{
    [TestFixture]
    public class ProjectImporterTests
    {
        private ProjectImporter Importer { get; set; }

        [SetUp]
        public void SetUp()
        {
            Importer = new();
        }

        [TestCaseSource(typeof(ImporterSource),nameof(ImporterSource.GetTestCaseData))]
        public async Task ImportAsyncTests(string fileName, Type expectedType)
        {
            var actualProject = await Importer.ImportAsync(fileName);

            Assert.IsInstanceOf(expectedType, actualProject);
        }
    }
}
