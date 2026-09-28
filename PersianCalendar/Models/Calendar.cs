using System;

namespace PersianCalendar.Models
{
    /// <summary>
    /// Represents a user-owned calendar (e.g. "Personal", "Work", "Family").
    /// A calendar holds events and optionally shares them with other users.
    /// </summary>
    public class Calendar : EntityBase
    {
        /// <summary>Display name of the calendar.</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Optional description.</summary>
        public string? Description { get; set; }

        /// <summary>Owner's user id.</summary>
        public string OwnerId { get; set; } = string.Empty;

        /// <summary>Whether the calendar is visible on the dashboard.</summary>
        public bool IsVisible { get; set; } = true;
    }
}