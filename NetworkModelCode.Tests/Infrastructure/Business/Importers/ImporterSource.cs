using NetworkModelCode.Core.Domain.Entities;

using NUnit.Framework;

using System.Collections.Generic;

namespace NetworkModelCode.Tests.Infrastructure.Business.Importers
{
    internal class ImporterSource
    {
        public static IEnumerable<TestCaseData> GetTestCaseData()
        {
            yield return new TestCaseData(@"D:\Test.txt", typeof(Project));
        }
    }
}
