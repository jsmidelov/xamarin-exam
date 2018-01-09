using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using FoodBook.UWP;
using Xamarin.Forms;
using FoodBook.Models;

[assembly: Dependency(typeof(PhoneDialer))]

namespace FoodBook.UWP
{
    public class PhoneDialer : IDialer
    {
        public Task<bool> DialAsync(string number)
        {
            if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.Calls.CallsPhoneContract", 1,0))
            {
                //Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI(number, "Phoneword");
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}