using System.Collections.Generic;

namespace NetworkModelCode.Core.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Title { get; set; }

        public int WorkCount { get; set; }

        public IReadOnlyList<TechnologicalCondition> TechnologicalConditions { get; set; }

        public IReadOnlyList<NetworkEvent> Events { get; set; }

        public IReadOnlyList<TimeCharacteristic> TimeCharacteristics { get; set; }

        public override string ToString() => $"{WorkCount}";
    }
}
