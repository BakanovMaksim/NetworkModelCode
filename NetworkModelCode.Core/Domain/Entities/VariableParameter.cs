using System.Collections.Generic;

namespace NetworkModelCode.Core.Domain.Entities
{
    /// <summary>
    /// Описывает варьируемые параметры.
    /// </summary>
    public class VariableParameter
    {
        /// <summary>
        /// Номер начала такта.
        /// </summary>
        public int StartCycleNumber { get; set; }

        /// <summary>
        /// Номер окончания такта.
        /// </summary>
        public int FinishCycleNumber { get; set; }

        /// <summary>
        /// Интенсивность потребления ресурса.
        /// </summary>
        public double ResourceConsumption { get; set; }

        /// <summary>
        /// Список номеров тактов потребления ресура.
        /// </summary>
        public IEnumerable<int> CycleNumberConsumptions { get; set; }
    }
}
