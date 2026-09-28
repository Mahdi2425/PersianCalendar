using System;

namespace PersianCalendar.Models
{
    /// <summary>
    /// The core domain entity: a calendar event.
    /// Supports Persian (Jalali) dates, recurrence, reminders, and categorization.
    /// </summary>
    public class Event : EntityBase
    {
        /// <summary>Display title.</summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>Optional description / notes.</summary>
        public string? Description { get; set; }

        /// <summary>Location of the event.</summary>
        public string? Location { get; set; }

        /// <summary>Start date/time (UTC).</summary>
        public DateTime StartDate { get; set; }

        /// <summary>End date/time (UTC).</summary>
        public DateTime EndDate { get; set; }

        /// <summary>All-day flag.</summary>
        public bool IsAllDay { get; set; }

        /// <summary>Recurrence pattern.</summary>
        public RepeatPattern Repeat { get; set; } = RepeatPattern.None;

        /// <summary>Optional custom recurrence end.</summary>
        public DateTime? RecurrenceEnd { get; set; }

        /// <summary>Foreign key to the owning calendar.</summary>
        public Guid CalendarId { get; set; }

        /// <summary>Navigation: the calendar this event belongs to.</summary>
        public Calendar? Calendar { get; set; }

        /// <summary>Foreign key to the event category.</summary>
        public Guid? CategoryId { get; set; }

        /// <summary>Navigation: the event category.</summary>
        public EventCategory? Category { get; set; }

        /// <summary>Owner's user id.</summary>
        public string OwnerId { get; set; } = string.Empty;
    }
}