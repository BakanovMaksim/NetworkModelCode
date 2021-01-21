using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetworkModelCode.Core.Domain.Entities
{
    public class WorkManager : BaseEntity
    {
        public int WorkCount { get; set; }

        public IReadOnlyList<WorkDataSource> WorkDataSources { get; set; }

        public IReadOnlyList<WorkTimeCharacteristic> WorkTimeCharacteristics { get; set; }

        public override string ToString() => $"{WorkCount}";
    }
}
