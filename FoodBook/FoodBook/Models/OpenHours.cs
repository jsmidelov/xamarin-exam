using SQLite;
using System;

namespace ExamApp.Models
{
    public class OpenHours
    {
        [PrimaryKey, AutoIncrement]
        public int OpenHoursId { get; set; }
        [NotNull]
        public int RestaurantId { get; set; }
        public DayOfWeek Weekday { get; set; }
        public DateTime Opens { get; set; }
        public DateTime Closes { get; set; }
    }
}
