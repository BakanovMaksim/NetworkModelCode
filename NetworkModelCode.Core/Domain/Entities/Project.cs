using System.Collections.Generic;

namespace NetworkModelCode.Core.Domain.Entities
{
    public class Project : BaseEntity
    {
        public int WorkCount { get; set; }

        public IReadOnlyList<ItemDataSource> ItemsDataSource { get; set; }

        public IReadOnlyList<ItemTimeCharacteristic> ItemsTimeCharacteristic { get; set; }

        public override string ToString() => $"{WorkCount}";
    }
}
