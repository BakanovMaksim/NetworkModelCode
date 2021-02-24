using System.Collections.Generic;

namespace NetworkModelCode.Core.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Title { get; set; }

        public int WorkCount { get; set; }

        public int CycleCount { get; set; }

        public IReadOnlyList<TechnologicalCondition> TechnologicalConditions { get; set; }

        public IReadOnlyList<Resource> Resources { get; set; }

        public IReadOnlyList<NetworkEvent> NetworkEvents { get; set; }

        public IReadOnlyList<TimeCharacteristic> TimeCharacteristics { get; set; }

        public override string ToString() => $"{WorkCount}";
    }
}
