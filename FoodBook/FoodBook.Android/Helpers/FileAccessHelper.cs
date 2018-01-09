using FoodBook.Models;

[assembly: Xamarin.Forms.Dependency(typeof(IFileHelper))]
namespace FoodBook.Droid.Helpers
{
    public class FileAccessHelper: IFileHelper
    {
        public FileAccessHelper()
        {
        }

        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);
        }
    }
}