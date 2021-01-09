using NetworkModelCode.Core.Domain.Entities;

using System.Collections.Generic;

namespace NetworkModelCode.Core.Domain.Builders
{
    public class MathModelTemporaryBuilder
    {
        private MathModelTemporary MathModelTemporary;

        public MathModelTemporaryBuilder()
        {
            MathModelTemporary = new MathModelTemporary();
        }

        public MathModelTemporaryBuilder SetEarlys(IEnumerable<int> earlyStarts, IEnumerable<int> earlyEnds)
        {
            MathModelTemporary.EarlyStarts = earlyStarts;
            MathModelTemporary.EarlyEnds = earlyEnds;
            return this;
        }

        public MathModelTemporaryBuilder SetLates(IEnumerable<int> lateStarts, IEnumerable<int> lateEnds)
        {
            MathModelTemporary.LateStarts = lateStarts;
            MathModelTemporary.LateEnds = lateEnds;
            return this;
        }

        public MathModelTemporaryBuilder SetReserves(IEnumerable<int> fullTimeReserves, IEnumerable<int> freeTimeReserves)
        {
            MathModelTemporary.FullTimeReserves = fullTimeReserves;
            MathModelTemporary.FreeTimeReserves = freeTimeReserves;
            return this;
        }

        public MathModelTemporary Build()
        {
            return MathModelTemporary;
        }
    }
}
