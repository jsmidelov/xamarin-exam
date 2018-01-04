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
        }

        class RestaurantMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<RestaurantMenuItem> MenuItems { get; set; }
            
            public RestaurantMasterViewModel()
            {
                MenuItems = new ObservableCollection<RestaurantMenuItem>(new[]
                {
                    new RestaurantMenuItem { Id = 0, Title = "Page 1" },
                    new RestaurantMenuItem { Id = 1, Title = "Page 2" },
                    new RestaurantMenuItem { Id = 2, Title = "Page 3" },
                    new RestaurantMenuItem { Id = 3, Title = "Page 4" },
                    new RestaurantMenuItem { Id = 4, Title = "Page 5" },
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