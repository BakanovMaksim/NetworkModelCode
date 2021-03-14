using System.ComponentModel.DataAnnotations.Schema;

namespace NetworkModelCode.Core.Domain.Entities
{
    public class TimeCharacteristic : BaseEntity
    {
        public int EarlyStart { get; set; }

        public int EarlyFinish { get; set; }

        public int LateStart { get; set; }

        public int LateFinish { get; set; }

        public int ReserveFullTime { get; set; }

        public int ReserveFreeTime { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public override bool Equals(object obj)
        {
            var itemTimeCharacteristic = obj as TimeCharacteristic;

            if (itemTimeCharacteristic == null)
                return false;

            return
                (this.EarlyStart == itemTimeCharacteristic.EarlyStart) && (this.EarlyFinish == itemTimeCharacteristic.EarlyFinish)
                && (this.LateStart == itemTimeCharacteristic.LateStart) && (this.LateFinish == itemTimeCharacteristic.LateFinish)
                && (this.ReserveFullTime == itemTimeCharacteristic.ReserveFullTime) && (this.ReserveFreeTime == itemTimeCharacteristic.ReserveFreeTime)
                ? true : false;
        }

        public override int GetHashCode()
        {
            return Id * 2;
        }
    }

    public static class WorkTimeCharacteristicExtension
    {
        public static string ToStringCustom(this TimeCharacteristic itemTimeCharacteristic)
        {
            return $"{itemTimeCharacteristic.EarlyStart} " +
                $"{itemTimeCharacteristic.EarlyFinish} " +
                $"{itemTimeCharacteristic.LateStart} " +
                $"{itemTimeCharacteristic.LateFinish} " +
                $"{itemTimeCharacteristic.ReserveFullTime} " +
                $"{itemTimeCharacteristic.ReserveFreeTime}";
        }
    }
}
