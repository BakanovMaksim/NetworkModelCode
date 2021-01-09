using NetworkModelCode.Core.Domain.Builders;
using NetworkModelCode.Core.Domain.Entities;

using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NetworkModelCode.Tests")]

namespace NetworkModelCode.Core.Application.Calculators
{
    public class MathModelTemporaryCalculator
    {
        private MathModelSource MathModelSource { get; }

        public MathModelTemporaryCalculator(MathModelSource mathModelSource)
        {
            MathModelSource = mathModelSource;
        }

        public MathModelTemporary Calculate()
        {
            var (earlyStarts, earlyEnds) = CalculateEarlyStartsAndEnds();
            var lateEnds = CalculateLateEnds(earlyEnds);
            var lateStarts = CalculateLateStarts(lateEnds);
            var fullTimeReserves = CalculateFullTimeReserves(lateEnds, earlyEnds);
            var freeTimeReserves = CalculateFreeTimeReserves(lateStarts, earlyStarts);

            return new MathModelTemporaryBuilder()
                .SetEarlys(earlyStarts, earlyEnds)
                .SetLates(lateStarts, lateEnds)
                .SetReserves(fullTimeReserves, freeTimeReserves)
                .Build();
        }

        internal (IEnumerable<int>, IEnumerable<int>) CalculateEarlyStartsAndEnds()   //TODO:  Рефакторинг
        {
            var earlyStarts = new List<int>();
            var earlyEnds = new List<int>();

            for (int i = 0; i < MathModelSource.NumberWorkCount; i++)
            {
                if (MathModelSource.WorkCodes[i].I == 1)
                {
                    earlyStarts.Add(0);
                    earlyEnds.Add(MathModelSource.ExecutionTimes[i]);
                    continue;
                }

                var counts = new List<int>();
                for (int j = 0; j < MathModelSource.NumberWorkCount; j++)
                {
                    if (MathModelSource.WorkCodes[i].I == MathModelSource.WorkCodes[j].J)
                    {
                        counts.Add(earlyEnds[j]);
                    }
                }

                var earlyStart = counts.Max();
                var earlyEnd = earlyStart + MathModelSource.ExecutionTimes[i];

                earlyStarts.Add(earlyStart);
                earlyEnds.Add(earlyEnd);
            }

            return (earlyStarts, earlyEnds);
        }

        internal IEnumerable<int> CalculateLateEnds(IEnumerable<int> earlyEnds)
        {
            var earlyEs = earlyEnds.ToList();

            var keys = MathModelSource.WorkCodes.
                GroupBy(p => p.J)
                .Select(p => new { Key = p.Key });

            foreach (var late in keys)
            {
                var earlys = new List<int>();
                for (int k = 0; k < MathModelSource.NumberWorkCount; k++)
                {
                    if (MathModelSource.WorkCodes[k].J == late.Key)
                    {
                        earlys.Add(earlyEs[k]);
                    }
                }

                for (int k = 0; k < earlys.Count; k++)
                    yield return earlys.Max();
            }
        }

        internal IEnumerable<int> CalculateLateStarts(IEnumerable<int> lateEnds)
        {
            var lateEs = lateEnds.ToList();

            for (int k = 0; k < MathModelSource.NumberWorkCount; k++)
            {
                yield return lateEs[k] - MathModelSource.ExecutionTimes[k];
            }
        }

        internal IEnumerable<int> CalculateFullTimeReserves(IEnumerable<int> lateEnds, IEnumerable<int> earlyEnds)
        {
            var lateEs = lateEnds.ToList();
            var earlyEs = earlyEnds.ToList();

            for (int k = 0; k < MathModelSource.NumberWorkCount; k++)
            {
                yield return lateEs[k] - earlyEs[k];
            }
        }

        internal IEnumerable<int> CalculateFreeTimeReserves(IEnumerable<int> lateStarts, IEnumerable<int> earlyStarts)
        {
            var lateSs = lateStarts.ToList();
            var earlySs = earlyStarts.ToList();

            for (int k = 0; k < MathModelSource.NumberWorkCount; k++)
            {
                yield return lateSs[k] - earlySs[k];
            }
        }
    }
}
