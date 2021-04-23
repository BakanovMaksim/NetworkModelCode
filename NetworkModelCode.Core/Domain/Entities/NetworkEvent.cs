namespace NetworkModelCode.Core.Domain.Entities
{
    /// <summary>
    /// Описывает сетевое событие.
    /// </summary>
    public class NetworkEvent : BaseEntity
    {
        /// <summary>
        /// Раннее свершение события.
        /// </summary>
        public int EarlyCompletionDate { get; set; }

        /// <summary>
        /// Позднее свершения события.
        /// </summary>
        public int LateCompletionDate { get; set; }

        public int TimeReserveCompletionDate { get; set; }

        /// <summary>
        /// Возвращает логический результат сравнения с другим экземпляром данного класса.
        /// </summary>
        /// <param name="obj"> Параметр экземпляр данного класса. </param>
        /// <returns> Логический результат сравнения. </returns>
        public override bool Equals(object obj)
        {
            var networkEvent = obj as NetworkEvent;

            if (networkEvent == null)
                return false;

            return (this.EarlyCompletionDate == networkEvent.EarlyCompletionDate)
                && (this.LateCompletionDate == networkEvent.LateCompletionDate)
                && (this.TimeReserveCompletionDate == networkEvent.TimeReserveCompletionDate)
                ? true
                : false;
        }

        /// <summary>
        /// Возвращает хэш код.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Id * 2;
        }
    }
}
