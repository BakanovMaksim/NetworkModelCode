using System.ComponentModel;

namespace NetworkModelCode.Desktop.DTO
{
    public class TechnologicalConditionDTO
    {
        [DisplayName("Наименование")]
        public  string Title { get; set; }

        [DisplayName("Код i")]
        public int CodeI { get; set; }

        [DisplayName("Код j")]
        public int CodeJ { get; set; }

        [DisplayName("Минимальная продолжительность")]
        public int TimeMin { get; set; }

        [DisplayName("Максимальная продолжительность")]
        public int TimeMax { get; set; }

        [DisplayName("Продолжительность")]
        public int Time { get; set; }
    }
}
