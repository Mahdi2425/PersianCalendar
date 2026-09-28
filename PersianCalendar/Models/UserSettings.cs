using System;

namespace PersianCalendar.Models
{
    /// <summary>
    /// Aggregates UI preferences for a user (theme, layout, etc.).
    /// </summary>
    public class UserSettings : EntityBase
    {
        /// <summary>Owner's user id.</summary>
        public string OwnerId { get; set; } = string.Empty;

        /// <summary>Selected theme: System, Light, or Dark.</summary>
        public ThemeMode Theme { get; set; } = ThemeMode.System;

        /// <summary>Whether the sidebar is collapsed by default.</summary>
        public bool SidebarCollapsed { get; set; }

        /// <summary>Preferred Persian date format string.</summary>
        public string DateFormat { get; set; } = "yyyy/MM/dd";
    }
}