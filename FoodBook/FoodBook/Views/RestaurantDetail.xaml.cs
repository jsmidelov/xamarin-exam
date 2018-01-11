using ExamApp.Models;
using FoodBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantDetail : ContentPage
    {
        public bool IsOpen
        {
            get
            {
                DateTime now = DateTime.Now;
                if (Item == null) return false;
                if (Item.OpenedHours == null) return !string.IsNullOrEmpty(Item.PhoneNumber);
                
                OpenHours hoursToday = Item.OpenedHours.Find(x => x.Weekday == now.DayOfWeek);
                if (hoursToday.Opens.Hour <= now.Hour && hoursToday.Closes.Hour > now.Hour)
                {
                    return true;
                }
                return false;
            }
        }

        public Restaurant Item { get; set; }
        public List<Dish> Menu { get; set; }
        public RestaurantDetail(Restaurant item)
        {
            Item = item;
            Menu = item.Menu;
            Menu = new List<Dish>
            {
                new Dish {Category = "Pasta",Id = 1, Name = "TestPasta",Price=79, WikiName="Pasta" },
                new Dish {Category = "Pizza",Id = 1, Name = "TestPizza",Price=79, WikiName="Pizza" }
            };

            InitializeComponent();
            //List.BindingContext = Menu;
            RegisterEvents();
        }
        // Need parameter in XAML in order to comment this out
        public RestaurantDetail()
        {
            // Using Id = 0 as a DataTrigger for XAML to disable Edit for non-existing restaurants
            Item = new Restaurant
            {
                Id = "0"
            };
            Menu = new List<Dish>
            {
                new Dish {Category = "Pasta",Id = 1, Name = "TestPasta",Price=79, WikiName="Pasta" },
                new Dish {Category = "Pizza",Id = 1, Name = "TestPizza",Price=79, WikiName="Pizza" }
            };

            InitializeComponent();
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            CallButton.Clicked += (s, e) => CallRestaurant();
            EditButton.Clicked += (s, e) => EditRestaurant();
            WikiButton.Clicked += (s, e) => CallWikipedia();
            //List.ItemTapped += (s,e) => CallWikipedia(e);
        }

        private async void CallWikipedia() // ItemTappedEventArgs e
        {
            // TODO: Find proper way to call wikipedia based on which button was presed
            var responseMessage = await App.Http.GetAsync("https://en.wikipedia.org/w/api.php?action=query&format=json&prop=extracts&exintro=true&redirects=true&titles=Pizza");
            WikipediaResult result = new WikipediaResult(await responseMessage.Content.ReadAsStringAsync());
            await DisplayAlert("About this dish",result.Extract,"OK");
            //throw new NotImplementedException();
        }

        public async void CallRestaurant()
        {
            // TODO Debug call method
            if (Item?.PhoneNumber == null)
            {
                await DisplayAlert("No number added", $"No number set for {Item.Title}", "What a shame");
                return;
            }
            await DisplayAlert("Placeholder call", $"Not calling {Item.PhoneNumber}", "Fine...");
            //var dialer = DependencyService.Get<IDialer>();
            //if (dialer != null)
            //{
            //    await dialer.DialAsync(Item.PhoneNumber);
            //}
        }

        public async void EditRestaurant()
        {
            await Navigation.PushAsync(new RestaurantForm(Item));
        }
    }
}