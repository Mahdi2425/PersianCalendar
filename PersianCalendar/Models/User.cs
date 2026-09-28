using System;

namespace PersianCalendar.Models
{
    /// <summary>
    /// Application user profile.
    /// </summary>
    public class User : EntityBase
    {
        /// <summary>Display name.</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Email address.</summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>Avatar URL.</summary>
        public string? Avatar { get; set; }

        /// <summary>Preferred calendar culture, e.g. "fa-IR".</summary>
        public string Culture { get; set; } = "fa-IR";

        /// <summary>Preferred calendar system, e.g. "Persian".</summary>
        public string CalendarSystem { get; set; } = "Persian";

        /// <summary>Preferred first day of week (0=Saturday for Persian).</summary>
        public int FirstDayOfWeek { get; set; } = 6;

        /// <summary>Time zone id.</summary>
        public string TimeZone { get; set; } = "Asia/Tehran";

        /// <summary>Whether the user has completed onboarding.</summary>
        public bool IsOnboarded { get; set; }
    }
}