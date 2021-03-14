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
                "A 1 2 5 10\nB 1 4 2 7\nC 1 5 1 6\nD 2 3 1 4\nE 2 8 8 13\nF 3 4 1 4\nG 3 6 9 19\nH 4 7 4 6\n" +
                "M 5 7 2 7\nN 6 8 7 12\nK 7 8 1 3\n" +
                "0 5 0 5 0 0\n0 2 3 5 3 3\n5 5 5 5 0 0\n5 8 9 12 4 4\n5 12 5 12 0 0\n5 11 5 11 0 0\n" +
                "12 16 12 16 0 0\n11 16 11 16 0 0",
                true,
                new Project
                {
                    WorkCount = 11,
                    TechnologicalConditions = new List<TechnologicalCondition>
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
                    },
                    TimeCharacteristics = new List<TimeCharacteristic>
                    {
                        new TimeCharacteristic{EarlyStart=0,EarlyFinish=5,LateStart=0,LateFinish=5,ReserveFullTime=0,ReserveFreeTime=0 },
                        new TimeCharacteristic{EarlyStart=0,EarlyFinish=2,LateStart=3,LateFinish=5,ReserveFullTime=3,ReserveFreeTime=3 },
                        new TimeCharacteristic{EarlyStart=5,EarlyFinish=5,LateStart=5,LateFinish=5,ReserveFullTime=0,ReserveFreeTime=0 },
                        new TimeCharacteristic{EarlyStart=5,EarlyFinish=8,LateStart=9,LateFinish=12,ReserveFullTime=4,ReserveFreeTime=4 },
                        new TimeCharacteristic{EarlyStart=5,EarlyFinish=12,LateStart=5,LateFinish=12,ReserveFullTime=0,ReserveFreeTime=0 },
                        new TimeCharacteristic{EarlyStart=5,EarlyFinish=11,LateStart=5,LateFinish=11,ReserveFullTime=0,ReserveFreeTime=0 },
                        new TimeCharacteristic{EarlyStart=12,EarlyFinish=16,LateStart=12,LateFinish=16,ReserveFullTime=0,ReserveFreeTime=0 },
                        new TimeCharacteristic{EarlyStart=11,EarlyFinish=16,LateStart=11,LateFinish=16,ReserveFullTime=0,ReserveFreeTime=0 }
                    }
                });

            yield return new TestCaseData(
                "   ",
                false,
                null);
        }
    }
}
