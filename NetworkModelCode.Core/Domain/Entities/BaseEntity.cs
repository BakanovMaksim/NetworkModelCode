using System.ComponentModel.DataAnnotations;

namespace NetworkModelCode.Core.Domain.Entities
{
    /// <summary>
    /// Описывает базовую сщуность.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
