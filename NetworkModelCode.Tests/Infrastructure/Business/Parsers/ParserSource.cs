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
                "A 1 2 5\nB 1 3 2\nC 2 3 0\nD 2 4 3\nE 3 4 7\nF 3 5 6\nG 4 6 4\nH 5 6 5\n" +
                "0 5 0 5 0 0\n0 2 3 5 3 3\n5 5 5 5 0 0\n5 8 9 12 4 4\n5 12 5 12 0 0\n5 11 5 11 0 0\n" +
                "12 16 12 16 0 0\n11 16 11 16 0 0",
                true,
                new Project
                {
                    WorkCount = 8,
                    ItemsDataSource = new List<ItemDataSource>
                    {
                        new ItemDataSource { Title = "A", CodeI = 1, CodeJ = 2, Time = 5 },
                        new ItemDataSource { Title = "B", CodeI = 1, CodeJ = 3, Time = 2 },
                        new ItemDataSource { Title = "C", CodeI = 2, CodeJ = 3, Time = 0 },
                        new ItemDataSource { Title = "D", CodeI = 2, CodeJ = 4, Time = 3 },
                        new ItemDataSource { Title = "F", CodeI = 3, CodeJ = 4, Time = 7 },
                        new ItemDataSource { Title = "E", CodeI = 3, CodeJ = 5, Time = 6 },
                        new ItemDataSource { Title = "G", CodeI = 4, CodeJ = 6, Time = 4 },
                        new ItemDataSource { Title = "H", CodeI = 5, CodeJ = 6, Time = 5 }
                    },
                    ItemsTimeCharacteristic = new List<ItemTimeCharacteristic>
                    {
                        new ItemTimeCharacteristic{EarlyStart=0,EarlyFinish=5,LateStart=0,LateFinish=5,ReserveFullTime=0,ReserveFreeTime=0 },
                        new ItemTimeCharacteristic{EarlyStart=0,EarlyFinish=2,LateStart=3,LateFinish=5,ReserveFullTime=3,ReserveFreeTime=3 },
                        new ItemTimeCharacteristic{EarlyStart=5,EarlyFinish=5,LateStart=5,LateFinish=5,ReserveFullTime=0,ReserveFreeTime=0 },
                        new ItemTimeCharacteristic{EarlyStart=5,EarlyFinish=8,LateStart=9,LateFinish=12,ReserveFullTime=4,ReserveFreeTime=4 },
                        new ItemTimeCharacteristic{EarlyStart=5,EarlyFinish=12,LateStart=5,LateFinish=12,ReserveFullTime=0,ReserveFreeTime=0 },
                        new ItemTimeCharacteristic{EarlyStart=5,EarlyFinish=11,LateStart=5,LateFinish=11,ReserveFullTime=0,ReserveFreeTime=0 },
                        new ItemTimeCharacteristic{EarlyStart=12,EarlyFinish=16,LateStart=12,LateFinish=16,ReserveFullTime=0,ReserveFreeTime=0 },
                        new ItemTimeCharacteristic{EarlyStart=11,EarlyFinish=16,LateStart=11,LateFinish=16,ReserveFullTime=0,ReserveFreeTime=0 }
                    }
                });

            yield return new TestCaseData(
                "   ",
                false,
                null);
        }
    }
}
