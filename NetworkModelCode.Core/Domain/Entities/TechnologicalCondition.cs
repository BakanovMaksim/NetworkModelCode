using System.ComponentModel.DataAnnotations.Schema;

namespace NetworkModelCode.Core.Domain.Entities
{
    /// <summary>
    /// Описывает технологическое условие.
    /// </summary>
    public class TechnologicalCondition : BaseEntity
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Шифр - i.
        /// </summary>
        public int CodeI { get; set; }

        /// <summary>
        /// Шифр - j.
        /// </summary>
        public int CodeJ { get; set; }

        /// <summary>
        /// Продолжительность.
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// Ресурсоемкость.
        /// </summary>
        public double ResourceCapacity { get; set; }

        /// <summary>
        /// Минимальное потребление ресурсов.
        /// </summary>
        public double ResourceConsumptionMin { get; set; }

        /// <summary>
        /// Максимальное потребление ресурсов.
        /// </summary>
        public double ResourceConsumptionMax { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        /// <summary>
        /// Возвращает логический результат сравнения с другим экземпляром данного класса.
        /// </summary>
        /// <param name="obj"> Параметр экземпляр данного класса. </param>
        /// <returns> Логический результат сравнения. </returns>
        public override bool Equals(object obj)
        {
            var itemDataSource = obj as TechnologicalCondition;

            if (itemDataSource == null)
            {
                return false;
            }

            return
                (this.CodeI == itemDataSource.CodeI) && (this.CodeJ == itemDataSource.CodeJ)
                ? true
                : false;
        }

        /// <summary>
        /// Возвращает хэш код.
        /// </summary>
        /// <returns> Хэш код. </returns>
        public override int GetHashCode()
        {
            return Id * 2;
        }
    }

    /// <summary>
    /// Расширяет взаимодействие с технологическим условием.
    /// </summary>
    public static class TechnologicalConditionExtension
    {
        /// <summary>
        /// Возвращает информацию технологического условия в текстовом виде.
        /// </summary>
        /// <param name="technologicalCondition"> Параметр технологическое условие. </param>
        /// <returns> Информация технологического условия. </returns>
        public static string ToStringCustom(this TechnologicalCondition technologicalCondition)
        {
            return $"{technologicalCondition.Title} " +
                   $"{technologicalCondition.CodeI}" +
                   $" {technologicalCondition.CodeJ} " +
                   $"{technologicalCondition.Time}";
        }
    }
}
