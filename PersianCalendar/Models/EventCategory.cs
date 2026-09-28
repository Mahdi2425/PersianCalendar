using System;

namespace PersianCalendar.Models
{
    /// <summary>
    /// A category/tag used to group events (e.g. "Meeting", "Personal", "Birthday").
    /// </summary>
    public class EventCategory : EntityBase
    {
        /// <summary>Display name.</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Optional description.</summary>
        public string? Description { get; set; }

        /// <summary>Owner's user id.</summary>
        public string OwnerId { get; set; } = string.Empty;
    }
}