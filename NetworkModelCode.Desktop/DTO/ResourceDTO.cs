using System.ComponentModel;

namespace NetworkModelCode.Desktop.DTO
{
    public class ResourceDTO
    {
        [DisplayName("Наименование")]
        public string Title { get; set; }

        [DisplayName("Количество")]
        public double Amount { get; set; }
    }
}
