namespace NetworkModelCode.Core.Domain.Entities
{
    public class NetworkEvent : BaseEntity
    {
        public int EarlyCompletionDate { get; set; }

        public int LateCompletionDate { get; set; }

        public int TimeReserveCompletionDate { get; set; }

        public override bool Equals(object obj)
        {
            var networkEvent = obj as NetworkEvent;

            if (networkEvent == null)
                return false;

            return (this.EarlyCompletionDate == networkEvent.EarlyCompletionDate)
                && (this.LateCompletionDate == networkEvent.LateCompletionDate)
                && (this.TimeReserveCompletionDate == networkEvent.TimeReserveCompletionDate)
                ? true : false;
        }

        public override int GetHashCode()
        {
            return Id * 2;
        }
    }
}
