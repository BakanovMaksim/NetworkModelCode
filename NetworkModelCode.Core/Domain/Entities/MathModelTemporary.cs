using System.Collections.Generic;

namespace NetworkModelCode.Core.Domain.Entities
{
    /// <summary>
    /// Временные характеристики
    /// </summary>
    public class MathModelTemporary : BaseEntity
    {
        /// <summary>
        /// Раннее начало выполнения работы (t^pн).
        /// </summary>
        public IEnumerable<int> EarlyStarts { get; set; }

        /// <summary>
        /// Раннее окончание выполнения работы (t^pо).
        /// </summary>
        public IEnumerable<int> EarlyEnds { get; set; }

        /// <summary>
        /// Позднее начало выполнения работы (t^пн).
        /// </summary>
        public IEnumerable<int> LateStarts { get; set; }

        /// <summary>
        /// Позднее окончание выполнения работы (t^по).
        /// </summary>
        public IEnumerable<int> LateEnds { get; set; }

        /// <summary>
        /// Полный резерв времени (r^п).
        /// </summary>
        public IEnumerable<int> FullTimeReserves { get; set; }

        /// <summary>
        /// Свободный резерв времени (r^с).
        /// </summary>
        public IEnumerable<int> FreeTimeReserves { get; set; }

        /// <summary>
        /// Резерв времени событий (R).
        /// </summary>
        public IEnumerable<int> EventTimeReserves { get; set; }
    }
}
