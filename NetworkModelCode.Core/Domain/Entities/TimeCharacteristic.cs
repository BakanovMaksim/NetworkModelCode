using System.ComponentModel.DataAnnotations.Schema;

namespace NetworkModelCode.Core.Domain.Entities
{
    /// <summary>
    /// Описывает временные характеристики.
    /// </summary>
    public class TimeCharacteristic : BaseEntity
    {
        /// <summary>
        /// Раннее начало.
        /// </summary>
        public int EarlyStart { get; set; }

        /// <summary>
        /// Раннее окончание.
        /// </summary>
        public int EarlyFinish { get; set; }

        /// <summary>
        /// Позднее начало.
        /// </summary>
        public int LateStart { get; set; }

        /// <summary>
        /// Позднее окончание,
        /// </summary>
        public int LateFinish { get; set; }

        /// <summary>
        /// Полный резерв времени.
        /// </summary>
        public int ReserveFullTime { get; set; }

        /// <summary>
        /// Свободный резерв времени.
        /// </summary>
        public int ReserveFreeTime { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        /// <summary>
        /// Возвращает логический результат сравнения с другим экземпляром данного класса.
        /// </summary>
        /// <param name="obj"> Параметр экземпляр данного класса. </param>
        /// <returns> Логический результат сравнения. </returns>
        public override bool Equals(object obj)
        {
            var itemTimeCharacteristic = obj as TimeCharacteristic;

            if (itemTimeCharacteristic == null)
            {
                return false;
            }

            return
                (this.EarlyStart == itemTimeCharacteristic.EarlyStart) && (this.EarlyFinish == itemTimeCharacteristic.EarlyFinish)
                && (this.LateStart == itemTimeCharacteristic.LateStart) && (this.LateFinish == itemTimeCharacteristic.LateFinish)
                && (this.ReserveFullTime == itemTimeCharacteristic.ReserveFullTime) && (this.ReserveFreeTime == itemTimeCharacteristic.ReserveFreeTime)
                ? true
                : false;
        }

        /// <summary>
        /// Возвращает хэш код
        /// </summary>
        /// <returns> Хэш код. </returns>
        public override int GetHashCode()
        {
            return Id * 2;
        }
    }

    /// <summary>
    /// Расширяет взаимодействие со временными характеристиками.
    /// </summary>
    public static class WorkTimeCharacteristicExtension
    {
        /// <summary>
        /// Возвращает информацию временных характеристик в текстовом виде.
        /// </summary>
        /// <param name="itemTimeCharacteristic"> Параметр временные характеристики. </param>
        /// <returns> Информация временных характеристик. </returns>
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
