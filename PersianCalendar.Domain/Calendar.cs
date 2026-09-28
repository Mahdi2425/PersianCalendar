using System.ComponentModel.DataAnnotations;
using PersianCalendar.Domain.Common;

namespace PersianCalendar.Domain
{
    public class Calendar : BaseEntity
    {
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(16)]
        public string Color { get; set; } = "#3788d8";

        [MaxLength(64)]
        public string TimeZone { get; set; } = "Asia/Tehran";

        public int OwnerId { get; set; }

        public User? Owner { get; set; }

        public bool IsVisible { get; set; } = true;

        public bool IsDefault { get; set; }

        public List<Event> Events { get; set; } = new();
    }
}
