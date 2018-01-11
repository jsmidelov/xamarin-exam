using FoodBook.UWP.Helpers;

namespace FoodBook.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            string dbPath = FileAccessHelper.GetLocalFilePath("data.db3");
            LoadApplication(new FoodBook.App(dbPath));
        }
    }
}
