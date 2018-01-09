using ExamApp.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RestaurantForm : ContentPage
    {
        private bool isNew;
        Restaurant Item { get; set; }

        /// <summary>
        /// Use empty constructor when adding new Restaurants
        /// </summary>
        public RestaurantForm()
		{
			InitializeComponent();
            Item = new Restaurant();
            isNew = true;
            BindingContext = Item;
		}

        /// <summary>
        /// Pass the parameter when editing an existing constructor
        /// </summary>
        /// <param name="item">The restaurant to be edited</param>
        public RestaurantForm(Restaurant item)
        {
            InitializeComponent();
            Item = item;
            isNew = false;
            BindingContext = Item;
            SaveButton.Clicked += (s,e) => SaveRestaurant();
        }

        private async void SaveRestaurant()
        {
            if (isNew)
            {
                // Create the added restaurant
            }
            else
            {
                // Update the edited restaurant
            }
            await Navigation.PopAsync();
        }
    }
}