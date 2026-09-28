using System.ComponentModel.DataAnnotations;
using PersianCalendar.Domain.Common;
using PersianCalendar.Domain.Enum;

namespace PersianCalendar.Domain
{
    public class Holiday : BaseEntity
    {
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        public int Day { get; set; }

        public int Month { get; set; }

        /// <summary>Use 0 with <see cref="IsRecurring"/> for holidays that repeat every year.</summary>
        public int Year { get; set; }

        public bool IsRecurring { get; set; }

        public bool IsOfficial { get; set; } = true;

        public HolidayType Type { get; set; } = HolidayType.National;

        [MaxLength(10)]
        public string Region { get; set; } = "IR";

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
