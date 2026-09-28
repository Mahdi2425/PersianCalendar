using PersianCalendar.Domain.Common;
using PersianCalendar.Domain.Enum;

namespace PersianCalendar.Domain
{
    public class Reminder : BaseEntity
    {
        public int EventId { get; set; }

        public Event? Event { get; set; }

        public int MinutesBefore { get; set; } = 15;

        public ReminderChannel Channel { get; set; } = ReminderChannel.Local;

        public bool IsEnabled { get; set; } = true;

        public DateTime? LastFiredAt { get; set; }
    }
}
