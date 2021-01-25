using System.ComponentModel;

namespace NetworkModelCode.Desktop.DTO
{
    public class WorkDataSourceDTO
    {
        [DisplayName("i")]
        public int CodeI { get; set; }

        [DisplayName("j")]
        public int CodeJ { get; set; }

        [DisplayName("Продолжительность")]
        public int Time { get; set; }
    }
}
