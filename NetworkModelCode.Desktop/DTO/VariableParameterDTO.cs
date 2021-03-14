using System.ComponentModel;

namespace NetworkModelCode.Desktop.DTO
{
    public class VariableParameterDTO
    {
        [DisplayName("x")]
        public int StartCycleNumber { get; set; }

        [DisplayName("y")]
        public int FinishCycleNumber { get; set; }

        [DisplayName("Интенсивность потреб.")]
        public double ResourceConsumption { get; set; }

        [DisplayName("Номера тактов")]
        public string CycleNumberConsumptions { get; set; }
    }
}
