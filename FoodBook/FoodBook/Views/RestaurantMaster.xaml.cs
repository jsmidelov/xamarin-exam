using ExamApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantMaster : ContentPage
    {
        public ListView ListView;

        public RestaurantMaster()
        {
            InitializeComponent();

            BindingContext = new RestaurantMasterViewModel();
            ListView = MenuItemsListView;
            
            AddButton.Clicked += (s,e) => AddRestaurant();
        }

        internal class RestaurantMasterViewModel : INotifyPropertyChanged
        {
            public static ObservableCollection<Restaurant> MenuItems { get; set; }

            public RestaurantMasterViewModel()
            {
                // TODO: Debug Create/Update-methods, then uncomment
                SetProperties(); // Intentionally non-awaited

                //MenuItems = new List<Restaurant>(new[]
                //{
                //    new Restaurant { Id = Guid.NewGuid().ToString(), Title = "Best Place" },
                //    new Restaurant { Id = Guid.NewGuid().ToString(), Title = "Almost Best Place" },
                //    new Restaurant { Id = Guid.NewGuid().ToString(), Title = "Pretty Decent Place" },
                //    new Restaurant { Id = Guid.NewGuid().ToString(), Title = "Okey Place" },
                //    new Restaurant { Id = Guid.NewGuid().ToString(), Title = "Quick Place" },
                //});
            }
            
            private async Task SetProperties()
            {
                List<Restaurant> list = await App.Repository.GetAllRestaurants();
                MenuItems = new ObservableCollection<Restaurant>(list);
                //MenuItems = await App.Repository.GetAllRestaurants();
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
        //Method handler for AddRestaurant
        public async void AddRestaurant()
        {
            await Navigation.PushAsync(new RestaurantForm());
        }
    }
}