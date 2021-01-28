using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Infrastructure.Business;

using NUnit.Framework;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetworkModelCode.Tests.Infrastructure.Business.Importers
{
    [TestFixture]
    public class WorkComplexImporterTests
    {
        private WorkComplexImporter Importer { get; set; }

        [SetUp]
        public void SetUp()
        {
            Importer = new();
        }

        [TestCaseSource(typeof(ImporterSource),nameof(ImporterSource.GetTestCaseData))]
        public async Task ImportAsyncTests(string fileName, IReadOnlyList<ItemDataSource> expected)
        {
            var actual = await Importer.ImportAsync(fileName);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
