using FoodBook.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExamApp.Models
{
    public class Restaurant
    {
        public Restaurant()
        {
            TargetType = typeof(RestaurantDetail);
        }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public Type TargetType { get; set; }
        public List<OpenHours> OpenedHours { get; set; }
        public ObservableCollection<Dish> Menu { get; set; }
    }
}