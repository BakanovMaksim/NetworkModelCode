using System.Collections.Generic;

namespace NetworkModelCode.Core.Domain.Entities
{
    public class VariableParameter
    {
        public int StartCycleNumber { get; set; }

        public int FinishCycleNumber { get; set; }

        public double ResourceConsumption { get; set; }

        public IEnumerable<int> CycleNumberConsumptions { get; set; }
    }
}
