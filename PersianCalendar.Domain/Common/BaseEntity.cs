using System.ComponentModel.DataAnnotations;

namespace PersianCalendar.Domain.Common
{
    /// <summary>
    /// Shared columns for every table.
    /// </summary>
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public Guid? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
