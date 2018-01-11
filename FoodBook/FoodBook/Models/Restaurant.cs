using FoodBook.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExamApp.Models
{
    [Table("Restaurant")]
    public class Restaurant
    {
        public Restaurant()
        {
            TargetType = typeof(RestaurantDetail);
        }
        [PrimaryKey, AutoIncrement]
        public int DbId { get; set; }
        [NotNull]
        public string Id { get; set; }
        [NotNull, MaxLength(250)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        [Ignore]
        public Type TargetType { get; set; }
        [Ignore]
        public List<OpenHours> OpenedHours { get; set; }
        [Ignore]
        public List<Dish> Menu { get; set; }
    }
}