using System.ComponentModel;

namespace NetworkModelCode.Desktop.DTO
{
    public class TimeCharacteristicDTO
    {
        [DisplayName("Раннее начало")]
        public int EarlyStart { get; set; }

        [DisplayName("Раннее окончание")]
        public int EarlyFinish { get; set; }

        [DisplayName("Позднее начало")]
        public int LateStart { get; set; }

        [DisplayName("Позднее окончание")]
        public int LateFinish { get; set; }

        [DisplayName("Общий резерв")]
        public int ReserveFullTime { get; set; }

        [DisplayName("Частный резерв")]
        public int ReserveFreeTime { get; set; }
    }
}
