using FoodBook.Models;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(IFileHelper))]
namespace FoodBook.iOS.Helpers
{    
    public class FileAccessHelper: IFileHelper
    {
        public FileAccessHelper()
        {
        }

        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = System.IO.Path.Combine(docFolder, "..", "Library", "Databases");

            if (!System.IO.Directory.Exists(libFolder))
            {
                System.IO.Directory.CreateDirectory(libFolder);
            }

            return System.IO.Path.Combine(libFolder, filename);
        }
    }
}