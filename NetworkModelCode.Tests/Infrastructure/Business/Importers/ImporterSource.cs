using NetworkModelCode.Core.Domain.Entities;

using NUnit.Framework;

using System.Collections.Generic;

namespace NetworkModelCode.Tests.Infrastructure.Business.Importers
{
    internal class ImporterSource
    {
        public static IEnumerable<TestCaseData> GetTestCaseData()
        {
            yield return new TestCaseData(@"D:\Test.txt",
                new List<ItemDataSource> 
                {
                    new ItemDataSource{CodeI=1,CodeJ=2,Time=5},
                    new ItemDataSource{CodeI=1,CodeJ=3,Time=2},
                    new ItemDataSource{CodeI = 2,CodeJ=3,Time=0},
                    new ItemDataSource{CodeI=2,CodeJ=4,Time=3},
                    new ItemDataSource{CodeI=3,CodeJ=4,Time=7},
                    new ItemDataSource{CodeI=3,CodeJ=5,Time=6},
                    new ItemDataSource{CodeI=4,CodeJ=6,Time=4},
                    new ItemDataSource{CodeI=5,CodeJ=6,Time=5}
                });
            yield return new TestCaseData(@"D:\Prag.txt", null);
        }
    }
}
