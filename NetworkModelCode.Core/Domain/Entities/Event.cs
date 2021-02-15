namespace NetworkModelCode.Core.Domain.Entities
{
    public class Event : BaseEntity
    {
        public int EarlyCompletionDate { get; set; }

        public int LateCompletionDate { get; set; }

        public int TimeReserveCompletionDate { get; set; }
    }
}
