using NetworkModelCode.Core.Domain.Entities;

using System.Collections.Generic;

namespace NetworkModelCode.Core.Domain.Builders
{
    public sealed class MathModelSourceBuilder
    {
        private MathModelSource MathModelSource { get; }

        public MathModelSourceBuilder()
        {
            MathModelSource = new MathModelSource();
        }

        public MathModelSourceBuilder SetNumberWorkCount(int count)
        {
            MathModelSource.NumberWorkCount = count;
            return this;
        }

        public MathModelSourceBuilder SetWorkCodes(IReadOnlyList<WorkCode> workCodes)
        {
            MathModelSource.WorkCodes = workCodes;
            return this;
        }

        public MathModelSourceBuilder SetWorkCodes(IReadOnlyList<int> workCodeIs, IReadOnlyList<int> workCodeJs)
        {
            var workCodes = new List<WorkCode>(workCodeIs.Count);

            for(int k = 0;k<workCodeIs.Count;k++)
            {
                workCodes.Add(new WorkCode(workCodeIs[k], workCodeJs[k]));
            }

            MathModelSource.WorkCodes = workCodes;
            return this;
        }

        public MathModelSourceBuilder SetExecutionTimes(IReadOnlyList<int> executionTimes)
        {
            MathModelSource.ExecutionTimes = executionTimes;
            return this;
        }

        public MathModelSource Build()
        {
            return MathModelSource;
        }
    }
}
