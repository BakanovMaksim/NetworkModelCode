using NetworkModelCode.Core.Domain.Entities;

namespace NetworkModelCode.Core.Domain.Builders
{
    public sealed class TimeCharacteristicBuilder
    {
        private TimeCharacteristic TimeCharacteristic { get; }

        public TimeCharacteristicBuilder()
        {
            TimeCharacteristic = new();
        }

        public TimeCharacteristicBuilder SetEarly(int earlyStart, int earlyFinish)
        {
            TimeCharacteristic.EarlyStart = earlyStart;
            TimeCharacteristic.EarlyFinish = earlyFinish;
            return this;
        }

        public TimeCharacteristicBuilder SetLate(int lateStart, int lateFinish)
        {
            TimeCharacteristic.LateStart = lateStart;
            TimeCharacteristic.LateFinish = lateFinish;
            return this;
        }

        public TimeCharacteristicBuilder SetReserve(int reserveFullTime, int reserveFreeTime)
        {
            TimeCharacteristic.ReserveFullTime = reserveFullTime;
            TimeCharacteristic.ReserveFreeTime = reserveFreeTime;
            return this;
        }

        public TimeCharacteristic Build()
        {
            return TimeCharacteristic;
        }
    }
}
