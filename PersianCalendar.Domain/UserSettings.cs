using System.ComponentModel.DataAnnotations;
using PersianCalendar.Domain.Common;
using PersianCalendar.Domain.Enum;

namespace PersianCalendar.Domain
{
    public class UserSettings : BaseEntity
    {
        public int OwnerId { get; set; }

        public User? Owner { get; set; }

        public ThemeMode Theme { get; set; } = ThemeMode.System;

        public bool SidebarCollapsed { get; set; }

        [MaxLength(32)]
        public string DateFormat { get; set; } = "yyyy/MM/dd";

        public bool ShowGregorianDates { get; set; } = true;

        public bool ShowHolidays { get; set; } = true;
    }
}
