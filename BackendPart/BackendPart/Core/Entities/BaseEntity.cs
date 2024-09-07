using System.ComponentModel.DataAnnotations;

namespace BackendPart.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public long id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

    }
}
