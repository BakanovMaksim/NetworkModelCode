using NetworkModelCode.Core.Domain.Entities;

using System;

namespace NetworkModelCode.Core.Domain.Builders
{
    /// <summary>
    /// Собирает технологические условия.
    /// </summary>
    public sealed class TechnologicalConditionBuilder
    {
        private TechnologicalCondition TechnologicalCondition { get; }

        /// <summary>
        /// Инициализирует свойства.
        /// </summary>
        public TechnologicalConditionBuilder()
        {
            TechnologicalCondition = new();
        }

        /// <summary>
        /// Присоединяет наименование.
        /// </summary>
        /// <param name="title"> Параметр наименование. </param>
        /// <returns> Данный объект технологических условий. </returns>
        public TechnologicalConditionBuilder SetTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("Передано пустое значение.", nameof(title));
            }

            TechnologicalCondition.Title = title;
            return this;
        }

        /// <summary>
        /// Присоединяет шифр работы.
        /// </summary>
        /// <param name="i"> Параметр шифр - i. </param>
        /// <param name="j"> Параметр шифр - j. </param>
        /// <returns> Данный объект технологических условий. </returns>
        public TechnologicalConditionBuilder SetCode(int i, int j)
        {
            if (i < 0)
            {
                throw new ArgumentException("Передано некорректное значение.", nameof(i));
            }

            if (j < 0)
            {
                throw new ArgumentException("Передано некорректное значение.", nameof(j));
            }

            TechnologicalCondition.CodeI = i;
            TechnologicalCondition.CodeJ = j;
            return this;
        }

        /// <summary>
        /// Присоединяет продолжительность.
        /// </summary>
        /// <param name="time"> Параметр продолжительность. </param>
        /// <returns> Данный объект технологических условий. </returns>
        public TechnologicalConditionBuilder SetTime(int time)
        {
            if (time < 0)
            {
                throw new ArgumentException("Передано некорректное значение.", nameof(time));
            }

            TechnologicalCondition.Time = time;
            return this;
        }

        /// <summary>
        /// Присоединяет ресурсные характеристики.
        /// </summary>
        /// <param name="capacity"> Параметр ресурсоемкость. </param>
        /// <param name="consumptionRateMin"> Параметр минимальное потребление ресурсов. </param>
        /// <param name="consumptionRateMax"> Параметр максимальное потребление ресурсов. </param>
        /// <returns> Данный объект техгнологических условий. </returns>
        public TechnologicalConditionBuilder SetResource(double capacity, double consumptionRateMin, double consumptionRateMax)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Передано некорректное значение.", nameof(capacity));
            }

            if (consumptionRateMin < 0)
            {
                throw new ArgumentException("Передано некорректное значение.", nameof(consumptionRateMin));
            }

            if (consumptionRateMax < 0)
            {
                throw new ArgumentException("Передано некорректное значение.", nameof(consumptionRateMax));
            }

            TechnologicalCondition.ResourceCapacity = capacity;
            TechnologicalCondition.ResourceConsumptionMin = consumptionRateMin;
            TechnologicalCondition.ResourceConsumptionMax = consumptionRateMax;

            return this;
        }

        /// <summary>
        /// Возвращает собранные технологические условия.
        /// </summary>
        /// <returns> Технологические условия. </returns>
        public TechnologicalCondition Build()
        {
            return TechnologicalCondition;
        }
    }
}
