using System.ComponentModel.DataAnnotations;
using PersianCalendar.Domain.Common;
using PersianCalendar.Domain.Enum;

namespace PersianCalendar.Domain
{
    public class Event : BaseEntity
    {
        [MaxLength(250)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string? Description { get; set; }

        [MaxLength(250)]
        public string? Location { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsAllDay { get; set; }

        [MaxLength(64)]
        public string TimeZone { get; set; } = "Asia/Tehran";

        [MaxLength(16)]
        public string? Color { get; set; }

        public RepeatPattern Repeat { get; set; } = RepeatPattern.None;

        /// <summary>Every N days/weeks/months depending on <see cref="Repeat"/>.</summary>
        public int RecurrenceInterval { get; set; } = 1;

        /// <summary>Comma-separated DayOfWeek values (0=Sunday ... 6=Saturday) for weekly recurrence.</summary>
        [MaxLength(32)]
        public string? RecurrenceDaysOfWeek { get; set; }

        public DateTime? RecurrenceEnd { get; set; }

        /// <summary>Optional max number of occurrences (null = until RecurrenceEnd or forever).</summary>
        public int? RecurrenceCount { get; set; }

        public bool IsCancelled { get; set; }

        public int? ParentEventId { get; set; }

        public Event? ParentEvent { get; set; }

        public List<Event> ExceptionEvents { get; set; } = new();

        public int CalendarId { get; set; }

        public Calendar? Calendar { get; set; }

        public int? CategoryId { get; set; }

        public EventCategory? Category { get; set; }

        public int OwnerId { get; set; }

        public User? Owner { get; set; }

        public List<Reminder> Reminders { get; set; } = new();
    }
}
