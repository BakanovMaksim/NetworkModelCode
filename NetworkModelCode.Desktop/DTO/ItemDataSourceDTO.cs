using System.ComponentModel;

namespace NetworkModelCode.Desktop.DTO
{
    public class ItemDataSourceDTO
    {
        [DisplayName("Название")]
        public  string Title { get; set; }

        [DisplayName("i")]
        public int CodeI { get; set; }

        [DisplayName("j")]
        public int CodeJ { get; set; }

        [DisplayName("Продолжительность")]
        public int Time { get; set; }
    }
}
