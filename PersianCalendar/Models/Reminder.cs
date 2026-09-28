using System;

namespace PersianCalendar.Models
{
    /// <summary>
    /// A reminder/notifications rule attached to an event.
    /// </summary>
    public class Reminder : EntityBase
    {
        /// <summary>Parent event id.</summary>
        public Guid EventId { get; set; }

        /// <summary>Minutes before the event start to trigger.</summary>
        public int MinutesBefore { get; set; } = 15;

        /// <summary>Channel: Push, Email, Sound.</summary>
        public string Channel { get; set; } = "Push";

        /// <summary>Whether the reminder is enabled.</summary>
        public bool IsEnabled { get; set; } = true;
    }
}