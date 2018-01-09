using SQLite;

namespace ExamApp.Models
{
    [Table("Dish")]
    public class Dish
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull, MaxLength(250)]
        public string Name { get; set; }
        public string Category { get; set; }
        public string RestaurantId { get; set; }
        public int Price { get; set; }
        public string WikiName { get; set; }
        public decimal Rating { get; set; }
    }
}
