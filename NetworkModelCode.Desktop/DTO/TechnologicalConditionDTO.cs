﻿using System.ComponentModel;

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

        [DisplayName("Время")]
        public int Time { get; set; }

        [DisplayName("Ресурсоемкость")]
        public double ResourceCapacity { get; set; }

        [DisplayName("Инт. потреб.(мин)")]
        public double ResourceConsumptionMin { get; set; }

        [DisplayName("Инт. потреб.(макс)")]
        public double ResourceConsumptionMax { get; set; }
    }
}
