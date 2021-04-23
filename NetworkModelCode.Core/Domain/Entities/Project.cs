using System.Collections.Generic;

namespace NetworkModelCode.Core.Domain.Entities
{
    /// <summary>
    /// Описывает проект пользователя.
    /// </summary>
    public class Project : BaseEntity
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Количество работ.
        /// </summary>
        public int WorkCount { get; set; }

        /// <summary>
        /// Количество тактов.
        /// </summary>
        public int CycleCount { get; set; }

        /// <summary>
        /// Список технологических условий.
        /// </summary>
        public IReadOnlyList<TechnologicalCondition> TechnologicalConditions { get; set; }

        /// <summary>
        /// Список сетевых событий.
        /// </summary>
        public IReadOnlyList<NetworkEvent> NetworkEvents { get; set; }

        /// <summary>
        /// Список временных характеристик.
        /// </summary>
        public IReadOnlyList<TimeCharacteristic> TimeCharacteristics { get; set; }

        /// <summary>
        /// Возвращает количество работ.
        /// </summary>
        /// <returns> Количество работ. </returns>
        public override string ToString() => $"{WorkCount}";
    }
}
