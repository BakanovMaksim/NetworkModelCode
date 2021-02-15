using System.ComponentModel.DataAnnotations;

namespace NetworkModelCode.Core.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
