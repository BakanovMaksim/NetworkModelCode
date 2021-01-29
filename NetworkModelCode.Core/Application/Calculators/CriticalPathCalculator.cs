using NetworkModelCode.Core.Domain.Entities;

using System.Collections.Generic;

namespace NetworkModelCode.Core.Application.Calculators
{
    public class CriticalPathCalculator
    {
        public int Calculate(IReadOnlyList<ItemDataSource> workDataSource, IReadOnlyList<ItemTimeCharacteristic> workTimeCharacteristics)
        {
            var criticalPathLength = 0;

            for(int k = 0;k<workDataSource.Count;k++)
            {
                if((workTimeCharacteristics[k].ReserveFullTime == 0) && (workTimeCharacteristics[k].ReserveFreeTime == 0))
                {
                    criticalPathLength += workDataSource[k].Time;
                }
            }

            return criticalPathLength;
        }
    }
}
