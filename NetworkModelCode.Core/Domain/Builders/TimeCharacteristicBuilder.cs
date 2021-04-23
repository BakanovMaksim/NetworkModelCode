using NetworkModelCode.Core.Domain.Entities;

using System;

namespace NetworkModelCode.Core.Domain.Builders
{
    /// <summary>
    /// Собирает временные характеристики.
    /// </summary>
    public sealed class TimeCharacteristicBuilder
    {
        private TimeCharacteristic TimeCharacteristic { get; }

        /// <summary>
        /// Инициализирует свойства.
        /// </summary>
        public TimeCharacteristicBuilder()
        {
            TimeCharacteristic = new();
        }

        /// <summary>
        /// Присоединяет ранние сроки. 
        /// </summary>
        /// <param name="earlyStart"> Параметр раннее начало. </param>
        /// <param name="earlyFinish"> Параметр раннее окончание. </param>
        /// <returns> Данный объект временных характеристик. </returns>
        public TimeCharacteristicBuilder SetEarly(int earlyStart, int earlyFinish)
        {
            if (earlyStart < 0)
            {
                throw new ArgumentException("Передано некорректное значение.", nameof(earlyStart));
            }

            TimeCharacteristic.EarlyStart = earlyStart;
            TimeCharacteristic.EarlyFinish = earlyFinish;
            return this;
        }

        /// <summary>
        /// Присоединяет поздние сроки.
        /// </summary>
        /// <param name="lateStart"> Параметр позднее начало. </param>
        /// <param name="lateFinish"> Параметр позднее окончание. </param>
        /// <returns> Данный объект временных характеристик. </returns>
        public TimeCharacteristicBuilder SetLate(int lateStart, int lateFinish)
        {
            if (lateStart < 0)
            {
                throw new ArgumentException("Передано некорректное значение.", nameof(lateStart));
            }

            if (lateFinish < 0)
            {
                throw new ArgumentException("Передано некорректное значение.", nameof(lateFinish));
            }

            TimeCharacteristic.LateStart = lateStart;
            TimeCharacteristic.LateFinish = lateFinish;
            return this;
        }

        /// <summary>
        /// Присоединяет резервные характеристики.
        /// </summary>
        /// <param name="reserveFullTime"> Параметр полный резерв. </param>
        /// <param name="reserveFreeTime"> Параметр свободный резерв. </param>
        /// <returns> Данный объект временных характеристик. </returns>
        public TimeCharacteristicBuilder SetReserve(int reserveFullTime, int reserveFreeTime)
        {
            TimeCharacteristic.ReserveFullTime = reserveFullTime;
            TimeCharacteristic.ReserveFreeTime = reserveFreeTime;
            return this;
        }

        /// <summary>
        /// Возвращает собранные временные характеристики.
        /// </summary>
        /// <returns> Временные характеристики. </returns>
        public TimeCharacteristic Build()
        {
            return TimeCharacteristic;
        }
    }
}
