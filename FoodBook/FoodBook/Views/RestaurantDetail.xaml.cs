using ExamApp.Models;
using FoodBook.Models;
using System;
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
        public ObservableCollection<Dish> Menu { get; set; }
        public RestaurantDetail(Restaurant item)
        {
            Item = item;
            Menu = item.Menu;
            InitializeComponent();
            //List.BindingContext = Menu;
            RegisterEvents();
        }
        // Need parameter in XAML in order to comment this out
        public RestaurantDetail()
        {
            InitializeComponent();
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            CallButton.Clicked += (s, e) => CallRestaurant();
            EditButton.Clicked += (s, e) => EditRestaurant();
            WikiButton.Clicked += (s, e) => CallWikipedia();
        }

        private async void CallWikipedia()
        {
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