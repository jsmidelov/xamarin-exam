using System;

namespace ExamApp.Models
{
    public class OpenHours
    {
        public WeekDay Weekday { get; set; }
        public DateTime Opens { get; set; }
        public DateTime Closes { get; set; }
    }
}
