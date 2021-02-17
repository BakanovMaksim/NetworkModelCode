using System.ComponentModel;

namespace NetworkModelCode.Desktop.DTO
{
    public class TechnologicalConditionDTO
    {
        [DisplayName("Наименование")]
        public  string Title { get; set; }

        [DisplayName("Код-i")]
        public int CodeI { get; set; }

        [DisplayName("Код-j")]
        public int CodeJ { get; set; }

        [DisplayName("Ресурсоемкость")]
        public double ResourceCapacity { get; set; }

        [DisplayName("Инт. потребления(мин)")]
        public double ResourceConsumptionRateMin { get; set; }

        [DisplayName("Инт. потребления(макс)")]
        public double ResourceConsumptionRateMax { get; set; }

        [DisplayName("Продолжительность(мин)")]
        public int TimeMin { get; set; }

        [DisplayName("Продолжительность(макс)")]
        public int TimeMax { get; set; }

        [DisplayName("Продолжительность(ож)")]
        public int Time { get; set; }
    }
}
