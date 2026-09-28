using System.ComponentModel.DataAnnotations;
using PersianCalendar.Domain.Common;

namespace PersianCalendar.Domain
{
    public class User : BaseEntity
    {
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Avatar { get; set; }

        [MaxLength(20)]
        public string Culture { get; set; } = "fa-IR";

        [MaxLength(50)]
        public string CalendarSystem { get; set; } = "Persian";

        /// <summary>Preferred first day of week (6 = Saturday for Persian).</summary>
        public int FirstDayOfWeek { get; set; } = 6;

        [MaxLength(64)]
        public string TimeZone { get; set; } = "Asia/Tehran";

        public bool IsOnboarded { get; set; }

        public UserSettings? Settings { get; set; }

        public List<Calendar> Calendars { get; set; } = new();

        public List<Event> Events { get; set; } = new();

        public List<EventCategory> Categories { get; set; } = new();
    }
}
