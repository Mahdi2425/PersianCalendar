using System.ComponentModel.DataAnnotations;

namespace PersianCalendar.Domain.Common
{
    /// <summary>
    /// For models that have a Title column.
    /// </summary>
    public abstract class BaseCategory : BaseEntity
    {
        [MaxLength(250)]
        public string? Title { get; set; }

        [MaxLength(250)]
        public string? Image { get; set; }
    }
}
