using FoodBook.Views;
using System.Net.Http;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

using Xamarin.Forms;
using FoodBook.Services;

namespace FoodBook
{
    public partial class App : Application
	{
        public static HttpClient Http { get; set; } = new HttpClient();
        public static Repository Repository { get; set; }
        public App ()
		{
			InitializeComponent();
            var rootPage = new RestaurantPage();
            var navPage = new NavigationPage(rootPage);
            MainPage = navPage;
            Repository = new Repository("data.db");
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
            AppCenter.Start(
                "android=58f20033-c19c-4107-b0cc-8fafa128aab9;",
                typeof(Analytics), typeof(Crashes));
            //+ "uwp={Your UWP App secret here};" + "ios={Your iOS App secret here}"
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
