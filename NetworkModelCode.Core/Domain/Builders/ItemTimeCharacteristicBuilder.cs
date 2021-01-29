using NetworkModelCode.Core.Domain.Entities;

namespace NetworkModelCode.Core.Domain.Builders
{
    public sealed class ItemTimeCharacteristicBuilder
    {
        private ItemTimeCharacteristic ItemTimeCharacteristic { get; }

        public ItemTimeCharacteristicBuilder()
        {
            ItemTimeCharacteristic = new();
        }

        public ItemTimeCharacteristicBuilder SetEarly(int earlyStart, int earlyFinish)
        {
            ItemTimeCharacteristic.EarlyStart = earlyStart;
            ItemTimeCharacteristic.EarlyFinish = earlyFinish;
            return this;
        }

        public ItemTimeCharacteristicBuilder SetLate(int lateStart, int lateFinish)
        {
            ItemTimeCharacteristic.LateStart = lateStart;
            ItemTimeCharacteristic.LateFinish = lateFinish;
            return this;
        }

        public ItemTimeCharacteristicBuilder SetReserve(int reserveFullTime, int reserveFreeTime)
        {
            ItemTimeCharacteristic.ReserveFullTime = reserveFullTime;
            ItemTimeCharacteristic.ReserveFreeTime = reserveFreeTime;
            return this;
        }

        public ItemTimeCharacteristic Build()
        {
            return ItemTimeCharacteristic;
        }
    }
}
