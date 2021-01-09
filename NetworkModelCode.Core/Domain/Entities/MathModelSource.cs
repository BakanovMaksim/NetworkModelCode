using System.Collections.Generic;

namespace NetworkModelCode.Core.Domain.Entities
{
    /// <summary>
    /// Исходные параметры.
    /// </summary>
    public class MathModelSource
    {
        public int NumberWorkCount { get; set; }

        /// <summary>
        /// Код работы.
        /// </summary>
        public IReadOnlyList<WorkCode> WorkCodes { get; set; }

        /// <summary>
        /// Длительность выполнения i-ой работы (t).
        /// </summary>
        public IReadOnlyList<int> ExecutionTimes { get; set; }
    }

    public class WorkCode
    {
        public int I { get; }

        public int J { get; }

        public WorkCode(int i,int j)
        {
            I = i;
            J = j;
        }
    }
}
