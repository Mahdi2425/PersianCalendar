using System.ComponentModel.DataAnnotations;
using PersianCalendar.Domain.Common;

namespace PersianCalendar.Domain
{
    public class EventCategory : BaseCategory
    {
        [MaxLength(16)]
        public string Color { get; set; } = "#3788d8";

        public int OwnerId { get; set; }

        public User? Owner { get; set; }

        public List<Event> Events { get; set; } = new();
    }
}
