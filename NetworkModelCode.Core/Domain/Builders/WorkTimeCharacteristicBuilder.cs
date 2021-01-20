using NetworkModelCode.Core.Domain.Entities;

namespace NetworkModelCode.Core.Domain.Builders
{
    public sealed class WorkTimeCharacteristicBuilder
    {
        private WorkTimeCharacteristic WorkTimeCharacteristic;

        public WorkTimeCharacteristicBuilder()
        {
            WorkTimeCharacteristic = new WorkTimeCharacteristic();
        }

        public WorkTimeCharacteristicBuilder SetEarly(int earlyStart, int earlyFinish)
        {
            WorkTimeCharacteristic.EarlyStart = earlyStart;
            WorkTimeCharacteristic.EarlyFinish = earlyFinish;
            return this;
        }

        public WorkTimeCharacteristicBuilder SetLate(int lateStart, int lateFinish)
        {
            WorkTimeCharacteristic.LateStart = lateStart;
            WorkTimeCharacteristic.LateFinish = lateFinish;
            return this;
        }

        public WorkTimeCharacteristicBuilder SetReserve(int reserveFullTime, int reserveFreeTime)
        {
            WorkTimeCharacteristic.ReserveFullTime = reserveFullTime;
            WorkTimeCharacteristic.ReserveFreeTime = reserveFreeTime;
            return this;
        }

        public WorkTimeCharacteristic Build()
        {
            return WorkTimeCharacteristic;
        }
    }
}
