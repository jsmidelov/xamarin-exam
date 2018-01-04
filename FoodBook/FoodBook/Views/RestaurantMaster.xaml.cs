using ExamApp.Models;
using System;
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
        }

        class RestaurantMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<Restaurant> MenuItems { get; set; }

            public RestaurantMasterViewModel()
            {
                MenuItems = new ObservableCollection<Restaurant>(new[]
                {
                    new Restaurant { Id = Guid.NewGuid().ToString(), Title = "Best Place" },
                    new Restaurant { Id = Guid.NewGuid().ToString(), Title = "Almost Best Place" },
                    new Restaurant { Id = Guid.NewGuid().ToString(), Title = "Pretty Decent Place" },
                    new Restaurant { Id = Guid.NewGuid().ToString(), Title = "Okey Place" },
                    new Restaurant { Id = Guid.NewGuid().ToString(), Title = "Quick Place" },
                });
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
    }
}