using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetworkModelCode.Core.Domain.Entities
{
    public class WorkComplex : BaseEntity
    {
        public int WorkCount { get; set; }

        public IReadOnlyList<ItemDataSource> WorkDataSources { get; set; }

        public IReadOnlyList<ItemTimeCharacteristic> WorkTimeCharacteristics { get; set; }

        public override string ToString() => $"{WorkCount}";
    }
}
