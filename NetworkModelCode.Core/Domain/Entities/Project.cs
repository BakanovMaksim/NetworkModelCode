using System.Collections.Generic;

namespace NetworkModelCode.Core.Domain.Entities
{
    public class Project : BaseEntity
    {
        public int WorkCount { get; set; }

        public IReadOnlyList<ItemDataSource> WorkDataSource { get; set; }

        public IReadOnlyList<ItemTimeCharacteristic> WorkTimeCharacteristics { get; set; }

        public int CriticalPathLength { get; set; }

        public override string ToString() => $"{WorkCount}";
    }
}
