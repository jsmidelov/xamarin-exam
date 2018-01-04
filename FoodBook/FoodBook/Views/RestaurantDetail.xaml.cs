using ExamApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantDetail : ContentPage
    {
        public Restaurant Item { get; set; }
        public ObservableCollection<Dish> Menu { get; set; }
        public RestaurantDetail(Restaurant item)
        {
            InitializeComponent();
            Item = item;
            Menu = item.Menu;
        }
        public RestaurantDetail()
        {
            InitializeComponent();
        }
    }
}