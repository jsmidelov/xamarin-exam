//using FoodBook.Models;

//[assembly: Xamarin.Forms.Dependency(typeof(IFileHelper))]
namespace FoodBook.UWP.Helpers
{
    public class FileAccessHelper//: IFileHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            string path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            return System.IO.Path.Combine(path, filename);
        }
    }
}
