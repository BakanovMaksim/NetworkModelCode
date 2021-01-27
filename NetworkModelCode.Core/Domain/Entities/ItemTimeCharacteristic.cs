using System;

namespace NetworkModelCode.Core.Domain.Entities
{
    public class ItemTimeCharacteristic : BaseEntity
    {
        public Guid WorkManagerId { get; set; }

        public int EarlyStart { get; set; }

        public int EarlyFinish { get; set; }

        public int LateStart { get; set; }

        public int LateFinish { get; set; }

        public int ReserveFullTime { get; set; }

        public int ReserveFreeTime { get; set; }
    }

    public static class WorkTimeCharacteristicExtension
    {
        public static string ToStringCustom(this ItemTimeCharacteristic itemTimeCharacteristic)
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
