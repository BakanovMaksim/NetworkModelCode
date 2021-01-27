using NetworkModelCode.Core.Domain.Entities;

using NUnit.Framework;

using System.Collections.Generic;

namespace NetworkModelCode.Tests.Infrastructure.Business.Parsers
{
    internal class ParserSource
    {
        internal static IEnumerable<TestCaseData> GetBuffers()
        {
            yield return new TestCaseData(
                "n=7\ni=1,2,5,3,4,11,6\nj=4,3,1,5,13,3,15\nt=1,2,3,4,5,6,7",
                true,
                new List<ItemDataSource>
                {
                    new(){CodeI = 1, CodeJ=4,Time=1},
                    new(){CodeI=2,CodeJ=3,Time=2},
                    new(){CodeI=5,CodeJ=1,Time=3},
                    new(){CodeI=3,CodeJ=5,Time=4},
                    new(){CodeI=4,CodeJ=13,Time=5},
                    new(){CodeI=11,CodeJ=3,Time=6},
                    new(){CodeI=6,CodeJ=15,Time=7}
                });

            yield return new TestCaseData(
                "   ",
                false,
                null);
        }
    }
}
